namespace Equipment.Infrastructure.Databases;

public class SqlConnectionBuilder(IConfiguration configuration, string connectionStringName, string tokenScope)
{
    private readonly IConfiguration _configuration = Guard.Against.Null(configuration, nameof(configuration));
    private readonly string _connectionStringName = Guard.Against.NullOrWhiteSpace(connectionStringName, nameof(connectionStringName));
    private readonly string _tokenScope = Guard.Against.NullOrWhiteSpace(tokenScope, nameof(tokenScope));

    public SqlConnection Build()
    {
        // Get the connection string from the configuration
        var connectionString = _configuration.GetConnectionString(_connectionStringName);
        connectionString = Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString), $"Connection string '{_connectionStringName}' not found.");

        // Check if the connection string contains a password
        if (connectionString.Contains("Password", StringComparison.CurrentCultureIgnoreCase))
        {
            return new SqlConnection(connectionString);
        }

        // Use Azure Identity to get the token for the connection
        var credential = new DefaultAzureCredential();
        var token = credential
            .GetToken(new TokenRequestContext([_tokenScope]), default)
            .Token;

        // Create a new SqlConnection with the connection string and token
        var sqlConnection = new SqlConnection(connectionString)
        {
            AccessToken = token
        };

        return sqlConnection;
    }
}
