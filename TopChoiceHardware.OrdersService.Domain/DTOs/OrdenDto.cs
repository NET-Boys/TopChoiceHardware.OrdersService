using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class OrdenDto
    {
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int AddressId { get; set; }
        public int Total { get; set; }
        public string Email { get; set; }

        //public MetodoPago PaymentMethod { get; set; }
    }
}
