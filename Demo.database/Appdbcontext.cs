using Demo.domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.database
{
    public class Appdbcontext : IdentityDbContext


    {
        
        
            public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
          {
            }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "sumit",
                    Email ="sumit123@gmail.com"
                },
                new Employee
                {
                    Id=2,
                    Name="prajjwal",
                    Email="prajjwal123@gmail.com"
                });
        }
    }
}

