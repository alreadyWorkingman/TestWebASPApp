using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	/// <summary>
	/// Класс работника
	/// </summary>
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }

		private int _age=18;
		/// <summary>
		/// Возраст работника. Заноситься в пределах [18;150)
		/// </summary>
		public int Age
		{
			get => _age; 
			set => _age = (value > 18 && value<150) ? value : 18; 
		}
		public bool IsMen { get; set; }

		private double _salary;
		/// <summary>
		/// Зарплата работника. Заноситься значение > 0
		/// </summary>
		public double Salary
		{
			get => _salary; 
			set => _salary = value > 0? value: 0;
		}
	}
}
