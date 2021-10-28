using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class OrdenProductoDto
    {
        public int OrdenId { get; set; }
        public int ProductId { get; set; }
        public Orden Orden { get; set; }
    }
}
