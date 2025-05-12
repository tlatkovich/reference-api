namespace Equipment.Infrastructure.Databases;

internal static class DatabaseConstants
{
    public const int SQL_DB_CONNECTION_COMMAND_TIMEOUT = 30;
    public const int SQL_DB_CONNECTION_MAX_RETRY_COUNT = 3;
    public const int SQL_DB_CONNECTION_MAX_RETRY_DELAY = 10;
    public const string AZURE_SQL_DB_CONNECTION_TOKEN_SCOPE = "https://database.windows.net//.default";
    public const string EQUIPMENT_DB_CONNECTION_STRING_NAME = "equipmentDb";
}
