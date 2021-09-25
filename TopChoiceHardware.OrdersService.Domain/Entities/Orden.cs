using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Domain.Entities
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int AddressId { get; set; }
        public int Total { get; set; }

        public MetodoPago PaymentMethod { get; set; }


    }
}
