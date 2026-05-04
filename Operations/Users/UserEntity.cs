using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Users
{
    public class UserEntity : EntityClass
    {
        public UserEntity()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }

        [PrimaryKey(Identity = true)]
        public int? id_usuario { get; set; }

        public string? username { get; set; }

        public string? password_hash { get; set; }

        public int? id_rol { get; set; }
    }
}