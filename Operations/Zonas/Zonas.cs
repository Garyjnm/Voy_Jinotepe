using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Zonas
{
    public class Zonas : EntityClass
    {
        public Zonas()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }

        [PrimaryKey(Identity = true)]
        public int? id_zona { get; set; }
        public string? nombre_zona { get; set; }
    }
}
