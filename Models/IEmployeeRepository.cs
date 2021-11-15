using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	/// <summary>
	/// Интерфейс репозитория для табилцы с контекста с сущностями Employee
	/// </summary>
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetAll();
		Employee Get(int id);
		void Add(Employee item);
		void Remove(int id);
		void Update(Employee item);
	}
}
