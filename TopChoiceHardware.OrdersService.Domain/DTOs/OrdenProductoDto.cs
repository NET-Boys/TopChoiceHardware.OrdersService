using System.Collections.Generic;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class OrdenProductoDto
    {
        public int OrdenId { get; set; }
        public int ProductId { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<Orden> Productos { get; set; }
    }
}
