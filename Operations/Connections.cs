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
            string password = Environment.GetEnvironmentVariable("SQL_PASSWORD") ?? "";
            string user = Environment.GetEnvironmentVariable("SQL_USER") ?? "";

            DBOrigen = SqlADOConexion.BuildDataMapper(".", "sa", "Rambito_12" , "VoyJinotepe");
            // DBDestino = SqlADOConexion.BuildDataMapper(".", user, password, "");

            // DBDestino?.GDatos.TestConnection();
            Console.WriteLine("Conexión a BD Destino exitosa");
            // DBOrigen?.GDatos.TestConnection();
        }
    }
}