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
    public class MedicamentosController : Controller

    {
        private readonly IMedicamentoservice _medicamentoservice;
        public MedicamentosController(IMedicamentoservice medicamentoservice)
        {
            _medicamentoservice = medicamentoservice;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _medicamentoservice.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _medicamentoservice.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Medicamentos model)
        {
            return Ok(
                _medicamentoservice.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Medicamentos model)
        {
            return Ok(
                _medicamentoservice.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _medicamentoservice.Delete(id)
               );
        }
    }
}
