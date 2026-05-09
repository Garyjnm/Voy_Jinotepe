using APPCORE;
using APPCORE.BDCore.Abstracts;
namespace BusinessLogic.Connection
{
    public class BDConnection
    {
        public WDataMapper? DBOrigen { get; set; }
        public WDataMapper? DBDestino { get; set; }
        public BDConnection()
        {
            // string password = Environment.GetEnvironmentVariable("SQL_PASSWORD") ?? throw new InvalidOperationException("SQL_PASSWORD no configurada");
            // string user = Environment.GetEnvironmentVariable("SQL_USER") ?? throw new InvalidOperationException("SQL_USER no configurada");
            // string server = Environment.GetEnvironmentVariable("SQL_SERVER") ?? ".";
            // string database = Environment.GetEnvironmentVariable("SQL_DATABASE") ?? "VoyJinotepe";

            DBOrigen = SqlADOConexion.BuildDataMapper(".", "sa", "Rambito_12", "VoyJinotepe");

            Console.WriteLine("Conexión a BD Origen exitosa");
        }
    }
}