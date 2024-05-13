using Demo.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.Employee
{
    public class GetEmployee
    {
        private Appdbcontext _ctx;

        public GetEmployee(Appdbcontext ctx)
        {
            _ctx = ctx;

        }
        public IEnumerable<EmployeeViewModel> Do()
        {
            return _ctx.Employees
                 .Select(x => new EmployeeViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Email = x.Email,
                 }).ToList();
        }
        public class EmployeeViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Email { get; set; }
        }
    }
}
