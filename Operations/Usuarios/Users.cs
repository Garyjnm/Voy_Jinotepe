using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Usuarios
{
    public class Users : EntityClass
    {
        public Users()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }

        [PrimaryKey(Identity = true)]
        public int? id_usuario { get; set; }

        public string? username { get; set; }

        public string? password { get; set; }

        public int? id_rol { get; set; }
    }
}