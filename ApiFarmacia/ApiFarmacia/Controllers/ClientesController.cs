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
    public class ClientesController : Controller

    {
        private readonly IClienteservice _clienteservice;
        public ClientesController(IClienteservice clienteservice)
        {
            _clienteservice = clienteservice;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _clienteservice.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _clienteservice.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Clientes model)
        {
            return Ok(
                _clienteservice.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Clientes model)
        {
            return Ok(
                _clienteservice.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _clienteservice.Delete(id)
               );
        }
    }
}
