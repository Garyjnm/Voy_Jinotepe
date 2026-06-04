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
            DBOrigen = SqlADOConexion.BuildDataMapper(".\\MYSQL", "sa", "Gary1234", "VoyJinotepe1");
            DBOrigen?.GDatos.TestConnection();
        }
    }
}