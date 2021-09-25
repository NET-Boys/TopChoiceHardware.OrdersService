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
    public class FacturaController : ControllerBase
    {
        private readonly IOrdenesService _service;

        public FacturaController(IOrdenesService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Factura), StatusCodes.Status201Created)]
        public IActionResult Post(FacturaDto facturaDto)
        {
            try
            {
                return new JsonResult(_service.CreateFactura(facturaDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
