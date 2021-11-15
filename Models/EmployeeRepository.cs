using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	/// <summary>
	/// Репозитрорий для таблицы Employee
	/// </summary>
	public class EmployeeRepository : IEmployeeRepository
	{
		private EmployeeContext _context;
		public EmployeeRepository(EmployeeContext context)
		{
			_context = context;
		}
		public void Add(Employee item)
		{
			var result = _context.Employeеs.Add(item).Entity;
			_context.SaveChanges();
		}

		public Employee Get(int id)
		{
			return _context.Employeеs.Find(id);
		}

		public IEnumerable<Employee> GetAll()
		{
			return _context.Employeеs.ToList();
		}

		public void Remove(int id)
		{
			var emp = this.Get(id);
			_context.Employeеs.Remove(emp);
			_context.SaveChanges();
		}

		public void Update(Employee item)
		{
			_context.Employeеs.Update(item);
			_context.SaveChanges();
		}
	}
}
