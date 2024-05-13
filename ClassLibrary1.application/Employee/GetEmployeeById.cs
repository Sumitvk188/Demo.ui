using Demo.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.Employee
{
    public class GetEmployeeById
    {
        private Appdbcontext _ctx;
        public GetEmployeeById(Appdbcontext ctx)
        {
            _ctx = ctx;
        }

        public EmpViewModel Do(int id)
        {
            return _ctx.Employees.Where(x => x.Id == id)
                .Select(x => new EmpViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,

                }
                ).FirstOrDefault();

        }
        public class EmpViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
