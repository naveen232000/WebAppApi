using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppApione.Models;

namespace WebAppApione.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employees : ControllerBase
    {
        static List<Employee>list=new List<Employee>() { 
        new Employee(){Id=1, FName="Sam",Lname="Kumar",Salary=56326},
        new Employee(){Id=2, FName="Jon",Lname="Son",Salary=56326},
        new Employee(){Id=3, FName="Leo",Lname="Das",Salary=56326},
        new Employee(){Id=4, FName="Geo",Lname="Fenc",Salary=56326},
        new Employee(){Id=5, FName="Navi",Lname="Ken",Salary=56326},
        };
        //GET
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return list;
        }
        //GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
           Employee emp =list.SingleOrDefault(x => x.Id == id);
            if(emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id) 
        {
            Employee emp = list.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(emp);
                return NoContent();
            }
        }
        //POST CREATE
        [HttpPost]
        public ActionResult<Employee> Post(Employee emp)
        {
          list.Add(emp);
            return (CreatedAtAction(nameof(Get),emp));
        }
        //PUT BY ID
        [HttpPut]
        public ActionResult<Employee> Put(int id,Employee upemp)
        {
           Employee emp=list.SingleOrDefault(x=>x.Id == id);
            if( emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.FName = upemp.FName;
                emp.Lname = upemp.Lname;
                emp.Salary = upemp.Salary;
                return NoContent ();
            }
        }
    }
}
