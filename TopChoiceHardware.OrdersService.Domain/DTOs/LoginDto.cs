using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Domain.DTOs
{
    public class LoginDto
    {
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
