using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class MetodoPagoDto
    {
        public int PaymentMethodId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
