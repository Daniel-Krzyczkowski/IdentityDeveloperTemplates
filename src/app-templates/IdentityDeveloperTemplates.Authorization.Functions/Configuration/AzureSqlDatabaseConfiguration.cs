using IdentityDeveloperTemplates.Authorization.Functions.Configuration.Interfaces;

namespace IdentityDeveloperTemplates.Authorization.Functions.Configuration
{
    internal class AzureSqlDatabaseConfiguration : IAzureSqlDatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
