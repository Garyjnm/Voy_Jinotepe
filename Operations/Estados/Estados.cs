using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Estados
{
    public class Estados : EntityClass
    {
        [PrimaryKey(Identity = true)]
        public int? id_estado { get; set; }
        public string nombre_estado { get; set; } = string.Empty;

        public Estados()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }
    }
}
