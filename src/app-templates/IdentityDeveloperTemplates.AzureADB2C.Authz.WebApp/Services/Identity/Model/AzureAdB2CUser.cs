using System;
using System.Collections.Generic;

namespace IdentityDeveloperTemplates.AzureADB2C.Authz.WebApp.Services.Identity.Model
{
    public class AzureAdB2CUser
    {
        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string ThumbnailPhoto { get; set; }
        public IReadOnlyList<SignInName> signInNames { get; set; }

        public class SignInName
        {
            public string type { get; set; }
            public string value { get; set; }
        }
    }
}
