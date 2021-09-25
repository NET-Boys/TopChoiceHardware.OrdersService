using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Domain.Entities
{
    public class MetodoPago
    {
        public int PaymentMethodId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
