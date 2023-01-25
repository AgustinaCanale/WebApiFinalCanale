using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            List<Department> departments = (from a in context.Departments
                                  where a.Name == name
                                  select a).ToList();
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






    }


}
