using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	public class EmployeesContext: DbContext
	{
        public DbSet<Employee> Employees { get; set; } //Таблица БД Employeеs

        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
            if (Database.EnsureCreated()) //Создаёт БД, если её нет
                Console.WriteLine("БД была создана");
        }

    }
}
