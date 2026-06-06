using APPCORE;
using BusinessLogic.Connection;
using System;

namespace Operations.Pedidos
{
    public class Pedidos : EntityClass
    {
        public Pedidos()
        {
            this.MDataMapper = new BDConnection().DBOrigen;
        }

        [PrimaryKey(Identity = true)]
        public int? id_pedido { get; set; }
        public int? id_cliente { get; set; }
        public int? id_repartidor { get; set; }
        public int? id_categoria { get; set; }
        public int? id_estado { get; set; }
        public decimal? monto_envio { get; set; }
        public DateTime? fecha_hora { get; set; }
    }
}
