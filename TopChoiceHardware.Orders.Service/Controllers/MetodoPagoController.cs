using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopChoiceHardware.OrdersService.Application.Services;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Domain.Entities;

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

        [HttpPost]
        [ProducesResponseType(typeof(MetodoPago), StatusCodes.Status201Created)]
        public IActionResult Post(MetodoPagoDto metodoPagoDto)
        {
            try
            {
                return new JsonResult(_service.CreateMetodoPago(metodoPagoDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
