using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
	public class HomeController : Controller
	{
		
		private readonly ILogger<HomeController> _logger;
		EmployeesContext _contextDb;
		public HomeController(ILogger<HomeController> logger, EmployeesContext context)
		{
			_logger = logger;
			_contextDb = context;
		}

		public IActionResult Index()
		{
			var a = _contextDb.Employees;
			return View(_contextDb.Employees.ToList());
			var z = 111;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public string Add(Employee emp)
		{
			_contextDb.Employees.Add(emp);
			// сохраняем в бд все изменения
			_contextDb.SaveChanges();
			return emp.Name + " добавлен";
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
