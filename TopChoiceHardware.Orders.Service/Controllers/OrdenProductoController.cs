﻿using Microsoft.AspNetCore.Http;
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
    public class OrdenProductoController : ControllerBase
    {
        private readonly IOrdenProductoService _service;

        public OrdenProductoController(IOrdenProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrdenProducto), StatusCodes.Status201Created)]
        public IActionResult Post(OrdenProductoDto ordenProductoDto)
        {
            try
            {
                return new JsonResult(_service.CreateOrdenProducto(ordenProductoDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetOrdenProducto()
        {
            try
            {
                var usuarios = _service.GetOrdenProducto();

                return Ok(usuarios);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOrdenProductoById(int id)
        {
            try
            {
                var usuario = _service.GetOrdenProductoById(id);
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
