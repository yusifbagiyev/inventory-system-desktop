using System.Configuration;

namespace Inventory_System.Classes
{
    /// <summary>Settings read from App.config, so no server address, password or key lives in the code.</summary>
    internal static class AppSettings
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["InventoryDb"]?.ConnectionString
            ?? throw new ConfigurationErrorsException("Connection string 'InventoryDb' is missing in App.config.");

        /// <summary>The SQL Server host from the connection string, without the instance name or port.</summary>
        public static string ServerHost =>
            new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString).DataSource.Split('\\', ',')[0];

        /// <summary>AES key for stored user passwords, which must be 16, 24 or 32 characters long.</summary>
        public static string PasswordKey =>
            ConfigurationManager.AppSettings["PasswordKey"]
            ?? throw new ConfigurationErrorsException("Setting 'PasswordKey' is missing in App.config.");
    }
}
