using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class SampleData
    {
        public static void Initialize(EmployeesContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(

                    new Employee
                    {
                        Name="Александра", 
                        Age =20, 
                        IsMen = false, 
                        Salary= 200.0 
                    },
                    new Employee
                    {
                        Name = "Вадим",
                        Age = 27,
                        IsMen = true,
                        Salary = 400
                    },
                    new Employee
                    { 
                        Name = "Николай",
                        Age = 18, 
                        IsMen = true, 
                        Salary = 150.0 
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
