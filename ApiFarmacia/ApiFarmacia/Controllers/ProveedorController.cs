﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ApiFarmacia.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProveedorController : Controller

    {
        private readonly IProveedorservice _proveedorservice;
        public ProveedorController(IProveedorservice proveedorservice)
        {
            _proveedorservice = proveedorservice;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _proveedorservice.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _proveedorservice.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Proveedor model)
        {
            return Ok(
                _proveedorservice.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Proveedor model)
        {
            return Ok(
                _proveedorservice.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _proveedorservice.Delete(id)
               );
        }
    }
}
