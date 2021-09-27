using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
