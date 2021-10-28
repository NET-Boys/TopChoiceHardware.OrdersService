using System;
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
