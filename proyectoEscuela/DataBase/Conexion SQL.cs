using Microsoft.Data.SqlClient;

namespace UniversidadPOO
{
    public static class DB
    {
        private static string connectionString = "Server=DESKTOP-ERONSA2;Database=UniversidadDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}