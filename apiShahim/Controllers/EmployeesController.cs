using apiShahim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace apiShahim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext db;
        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var emp =await db.Employees.FindAsync(id);
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)// new Employee// new ID
        {
            db.Employees.Add(employee);
          await  db.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id= employee .ID},employee);
        }

    }
}
