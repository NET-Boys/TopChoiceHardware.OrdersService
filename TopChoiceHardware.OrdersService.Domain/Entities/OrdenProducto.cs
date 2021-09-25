using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Domain.Entities
{
    public class OrdenProducto
    {
        public int OrdenProductoId { get; set; }
        public int OrdenId { get; set; }
        public int ProductId { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Orden> Productos { get; set; }

    }
}
