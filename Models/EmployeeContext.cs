using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    /// <summary>
    /// Класс контексат данных для БД с работниками
    /// </summary>
	public class EmployeeContext: DbContext
	{
        public DbSet<Employee> Employeеs { get; set; } //Таблица БД Employeеs

        private readonly ILogger<EmployeeContext> _logger;
        public EmployeeContext(ILogger<EmployeeContext> logger,DbContextOptions<EmployeeContext> options)
            : base(options)
        {
            _logger = logger;
            if (Database.EnsureCreated()) //Создаёт БД, если её нет
            {
                logger.LogInformation("Db was created");
            }
        }

    }
}
