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
        private readonly IFacturaService _service;

        public FacturaController(IFacturaService service)
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
        [HttpGet]
        public IActionResult GetFactura()
        {
            //try
            //{
                var usuarios = _service.GetFactura();

                return Ok(usuarios);
            //}
            //catch (Exception)
            //{

            //    return StatusCode(500, "Internal server error");
            //}
        }
        [HttpGet("{id}")]
        public IActionResult GetFacturaById(int id)
        {
            //try
            //{
                var usuario = _service.GetFacturaById(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            //}
            //catch (Exception)
            //{

            //    return StatusCode(500, "Internal server error");
            //}
        }

    }
}
