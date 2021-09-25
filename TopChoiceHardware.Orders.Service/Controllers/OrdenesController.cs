using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopChoiceHardware.OrdersService.Domain.Entities;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Application.Services;

namespace TopChoiceHardware.Orders.Service.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class OrderController : ControllerBase
        {
            private readonly IOrdenesService _service;

            public OrderController(IOrdenesService service)
            {
                _service = service;
            }

            [HttpPost]
            [ProducesResponseType(typeof(Orden), StatusCodes.Status201Created)]
            public IActionResult Post(OrdenDto ordendto)
            {
                try
                {
                    return new JsonResult(_service.CreateOrden(ordendto)) { StatusCode = 201 };
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }


        }
    
}
