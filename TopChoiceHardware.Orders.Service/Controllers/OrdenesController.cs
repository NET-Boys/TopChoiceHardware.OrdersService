using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TopChoiceHardware.OrdersService.Application.Services;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.Orders.Service.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class OrderController : ControllerBase
        {
            private readonly IOrdenesService _service;
            private readonly IEmailService _emailService;

            public OrderController(IOrdenesService service, IEmailService emailService)
            {
                _service = service;
                _emailService = emailService;
            }

            [HttpPost]
            [ProducesResponseType(typeof(Orden), StatusCodes.Status201Created)]
            public IActionResult Post(OrdenDto ordendto)
            {
                try
                {
                    _emailService.SendEmailAsync(ordendto.Email, ordendto.Total);
                    return new JsonResult(_service.CreateOrden(ordendto)) { StatusCode = 201 };
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            [HttpGet]
            public IActionResult GetOrden()
            {
                try
                {
                    var ordenes = _service.GetOrden();

                    return Ok(ordenes);
                }
                catch (Exception)
                {

                    return StatusCode(500, "Internal server error");
                }
            }
            [HttpGet("{ordenId}")]
            public IActionResult GetOrdenById(int ordenId)
            {
                try
                {
                    var usuario = _service.GetOrdenById(ordenId);
                    if (usuario == null)
                    {
                        return NotFound();
                    }

                    return Ok(usuario);
                }
                catch (Exception)
                {

                    return StatusCode(500, "Internal server error");
                }
            }

        }
    
}
