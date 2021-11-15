using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    /// <summary>
    /// Класс для создания начальных записей в табилце
    /// </summary>
    public static class SampleData
    {
        /// <summary>
        /// Добавляет 3 записи о работниках, если таблица пуста.
        /// </summary>
        /// <param name="context"> Контекст БД с Employeеs</param>
        public static void Initialize(EmployeeContext context)
        {
            if (!context.Employeеs.Any())
            {
                context.Employeеs.AddRange(

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
