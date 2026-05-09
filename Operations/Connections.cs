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
            DBOrigen = SqlADOConexion.BuildDataMapper(".", "sa", "Rambito_12", "VoyJinotepe");
            DBOrigen?.GDatos.TestConnection();
        }
    }
}