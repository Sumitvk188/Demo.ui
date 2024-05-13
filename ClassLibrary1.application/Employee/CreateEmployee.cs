using Demo.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.Employee
{
    public class CreateEmployee
    {
        private readonly Appdbcontext _context;
        public CreateEmployee(Appdbcontext context)
        {
            _context = context;

        }
        public async Task<Response> Do(Request request)
        {
            var Emp = new Demo.domain.Employee
            {
                Name = request.Name,
                Id = request.Id,
                Email = request.Email,
            };
            _context.Employees.Add(Emp);
            await _context.SaveChangesAsync();

            return new Response
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
            };

        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }


        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

        }
    }
}
