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

            DBOrigen = SqlADOConexion.BuildDataMapper(".", "sa", password, "");
            DBDestino = SqlADOConexion.BuildDataMapper(".", "sa", password, "");
            DBDestino?.GDatos.TestConnection();
            DBOrigen?.GDatos.TestConnection();
        }
    }
}