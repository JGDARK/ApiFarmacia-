using System;
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
    public class EmpleadosController : Controller

    {
        private readonly IEmpleadosservices _empleadosservice;
        public EmpleadosController(IEmpleadosservices empleadosservices)
        {
            _empleadosservice = empleadosservices;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _empleadosservice.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _empleadosservice.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Empleados model)
        {
            return Ok(
                _empleadosservice.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Empleados model)
        {
            return Ok(
                _empleadosservice.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _empleadosservice.Delete(id)
               );
        }
    }
}
