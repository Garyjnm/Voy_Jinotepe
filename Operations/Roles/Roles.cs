using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Roles
{
    public class Roles : EntityClass
    {
        public Roles() => this.MDataMapper = new BDConnection().DBOrigen;

        [PrimaryKey(Identity = true)]
        public int? id_rol { get; set; }
        public string? nombre_rol { get; set; }
    }
}