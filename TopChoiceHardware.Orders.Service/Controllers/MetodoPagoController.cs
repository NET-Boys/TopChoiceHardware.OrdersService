using Microsoft.AspNetCore.Mvc;
using System;
using TopChoiceHardware.OrdersService.Application.Services;

namespace TopChoiceHardware.Orders.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService _service;

        public MetodoPagoController(IMetodoPagoService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetMetodoPago()
        {
            try
            {
                var MetodoPago = _service.GetMetodoPago();

                return Ok(MetodoPago);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
