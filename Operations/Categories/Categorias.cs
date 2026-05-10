using APPCORE;
using BusinessLogic.Connection;

namespace Operations.Categories
{
    public class Categorias : EntityClass
    {
        public Categorias()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }

        [PrimaryKey(Identity = true)]
        public int? id_categoria { get; set;}
        public string? nombre_categoria {get; set;}
    }
}