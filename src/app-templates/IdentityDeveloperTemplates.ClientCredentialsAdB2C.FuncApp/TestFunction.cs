using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityDeveloperTemplates.ClientCredentialsAdB2C.FuncApp
{
    public class TestFunction
    {
        private readonly IConfidentialClientApplication _confidentialClient;
        private readonly AzureAdB2cSettings _azureAdB2cSettings;
        private readonly HttpClient _httpClient;

        public TestFunction(IConfidentialClientApplication confidentialClient,
                            IOptions<AzureAdB2cSettings> azureAdB2cSettings,
                            IHttpClientFactory httpClientFactory)
        {
            _confidentialClient = confidentialClient;
            _azureAdB2cSettings = azureAdB2cSettings.Value;
            _httpClient = httpClientFactory.CreateClient();
        }

        [Function("TestFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("TestFunction");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            AuthenticationResult result = await _confidentialClient
                                               .AcquireTokenForClient(new string[] { _azureAdB2cSettings.Scope })
                                               .ExecuteAsync();

            var accessToken = result.AccessToken;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var testDataEndpointResponse = await _httpClient.GetAsync("http://localhost:5000/testdata");

            if (testDataEndpointResponse.IsSuccessStatusCode)
            {
                var responseData = await testDataEndpointResponse.Content.ReadAsStringAsync();
                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                response.WriteString(responseData);
                return response;
            }

            else
            {
                var response = req.CreateResponse(HttpStatusCode.Forbidden);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                response.WriteString("Access to Test Data endpoint is forbidden");
                return response;
            }
        }
    }
}
