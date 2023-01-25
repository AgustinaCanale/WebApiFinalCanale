using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Canale.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWAdventureWorks_Canale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly AdventureWorks2019Context context;
        //contructor 

        public DepartmentController(AdventureWorks2019Context context)
        {

            this.context = context;

        }


        
        [HttpGet]


        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            Department department = (from d in context.Departments
                           where d.DepartmentId == id
                           select d).FirstOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }


        [HttpGet("listado/{Name}")]
        public ActionResult<IEnumerable<Department>> GetName(string name)
        {
            List<Department> departments = (from d in context.Departments
                                  where d.Name == name
                                  select d).ToList();
            return departments;


        }




        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(int id)
        {

            Department department = (from d in context.Departments
                                   where d.DepartmentId == id
                                   select d).SingleOrDefault();
            if (department == null)
            {
                return NotFound();
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return department;
        }


    }


}
