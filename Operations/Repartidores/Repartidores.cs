using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Repartidores
{
    public class Repartidores : EntityClass
    {
        [PrimaryKey(Identity = true)]
        public int? id_repartidor { get; set; }
        public int? id_usuario { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public bool? activo { get; set; }

        public Repartidores()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }
    }
}
