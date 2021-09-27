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

        public int UserId { get; set; }
        public int OrdenId { get; set; }
        public DateTime Date { get; set; }
        public Orden Orden { get; set; }


    }
}
