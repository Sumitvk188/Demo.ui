using Demo.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.Employee
{
    public class EditEmployee
    {
        private Appdbcontext _ctx;

        public EditEmployee(Appdbcontext context)
        {
            _ctx = context;
        }

        public async Task<Response> Do(Request request)
        {
            var emp = _ctx.Employees.Where(x => x.Id == request.Id).FirstOrDefault();

            emp.Id = request.Id;
            emp.Name = request.Name;
            emp.Email = request.Email;


            await _ctx.SaveChangesAsync();
            return new Response
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
            };
        }
        [Serializable]
        public class Request
        {
            public Request()
            {

            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        [Serializable]
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

        }
    }
}
