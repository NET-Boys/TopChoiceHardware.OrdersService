using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class FacturaDto
    {

        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        public OrdenDto Orden { get; set; }
        public OrdenDto User { get; set; }


        
    }
}
