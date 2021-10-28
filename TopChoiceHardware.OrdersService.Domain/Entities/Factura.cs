using System;

namespace TopChoiceHardware.OrdersService.Domain.Entities
{
    public class Factura
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int OrdenId { get; set; }
        public DateTime Date { get; set; }

        public Orden Orden { get; set; }

    }
}
