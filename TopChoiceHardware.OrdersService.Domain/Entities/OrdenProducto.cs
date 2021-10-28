namespace TopChoiceHardware.OrdersService.Domain.Entities
{
    public class OrdenProducto
    {
        public int OrdenProductoId { get; set; }
        public int OrdenId { get; set; }
        public int ProductId { get; set; }
        public Orden Orden { get; set; }

    }
}
