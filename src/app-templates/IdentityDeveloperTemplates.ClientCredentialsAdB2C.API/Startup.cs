using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IdentityDeveloperTemplates.ClientCredentialsAdB2C.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer("ClientCredentialsScheme", jwtOptions =>
                     {
                         jwtOptions.MetadataAddress = Configuration["AzureAdB2C:MetadataAddress"];
                         jwtOptions.Authority = Configuration["AzureAdB2C:Authority"];
                         jwtOptions.Audience = Configuration["AzureAdB2C:ClientId"];
                     });

            services.AddAuthorization(options =>
            {
                var authorizationPolicy = new AuthorizationPolicyBuilder()
                                              .RequireRole("access:test-api")
                                              .AddAuthenticationSchemes("ClientCredentialsScheme")
                                              .Build();
                options.AddPolicy("OnlyAuthorizedAccess", authorizationPolicy);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMF.Test.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMF.Test.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
