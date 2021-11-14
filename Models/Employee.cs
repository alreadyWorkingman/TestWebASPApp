using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	public class Employee
	{
		
		public int Id { get; set; }
		public string Name { get; set; }

		private int _age=18;
		public int Age
		{
			get { return _age; }
			set { _age = value > 18 ? value : 18; }
		}

		public bool IsMen { get; set; }


		private double _salary;
		public double Salary
		{
			get { return _salary; }
			set { _salary = value > 0? value: 0; }
		}
	}
}
