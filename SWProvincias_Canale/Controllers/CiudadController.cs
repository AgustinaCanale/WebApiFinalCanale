using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Canale.Data;
using SWProvincias_Canale.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Canale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        private readonly DBPaisFinalContext context;
        //contructor 
        public CiudadController(DBPaisFinalContext context)
        {

            this.context = context;

        }



        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Ciudad> GetById(int id)
        {
            Ciudad ciudad = (from c in context.Ciudades
                                   where c.IdCiudad == id
                                   select c).FirstOrDefault();
            if (ciudad == null)
            {
                return NotFound();
            }
            return ciudad;
        }


        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }




        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {

            Ciudad ciudad = (from c in context.Ciudades
                                   where c.IdCiudad == id
                                   select c).SingleOrDefault();
            if (ciudad == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;
        }
    }
}
