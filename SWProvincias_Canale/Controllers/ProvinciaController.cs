using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SWProvincias_Canale.Data;
using SWProvincias_Canale.Models;

namespace SWProvincias_Canale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {

        private readonly DBPaisFinalContext context;
        //contructor 
        public ProvinciaController(DBPaisFinalContext context)
        {

            this.context = context;

        }

        //GET: api/provincia
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Provincia> GetById(int id)
        {
           Provincia provincia = (from p in context.Provincias
                           where p.IdProvincia == id
                           select p).FirstOrDefault();
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }

        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {

            Provincia provincia = (from c in context.Provincias
                           where c.IdProvincia == id
                           select c).SingleOrDefault();
            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;
        }
    }
}
