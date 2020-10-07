namespace IdentityDeveloperTemplates.Authorization.Functions.Configuration.Interfaces
{
    public interface IAzureSqlDatabaseConfiguration
    {
        string ConnectionString { get; set; }
    }
}
