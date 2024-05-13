
using Demo.application.Employee;
using Demo.database;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ui.Controllers
{
    [Route("[controller]")]
   
    public class EmployeeController : Controller
    {
        private Appdbcontext _ctx;


        public EmployeeController(Appdbcontext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("")]

        public IActionResult GetAllEmployees() => Ok(new GetEmployee(_ctx).Do());

        [HttpPut("")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EditEmployee.Request request) => Ok(await new EditEmployee(_ctx).Do(request));

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id) => Ok(new GetEmployeeById(_ctx).Do(id));
    }
}
