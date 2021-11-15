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
	/// <summary>
	/// Основной контроллер
	/// </summary>
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		EmployeeRepository _employeeRepo;

		public HomeController(ILogger<HomeController> logger, EmployeeContext context)
		{
			_logger = logger;
			_employeeRepo = new EmployeeRepository(context);
		}

		public IActionResult Index()
		{
			LogRequestInfo();
			return View(_employeeRepo.GetAll());
		}

		[HttpGet]
		public IActionResult Add()
		{
			LogRequestInfo();
			return View();
		}
		[HttpPost]
		public string Add(Employee emp)
		{
			LogRequestInfo();
			_employeeRepo.Add(emp);
			_logger.LogInformation($"Record with id = {emp.Id} added");
			return emp.Name + " добавлен!";
		}


		[HttpGet]
		public IActionResult Update(int? id)
		{
			LogRequestInfo();
			var errAction = NullChecker(id);
			if (errAction != null)
				return errAction;

			var emp = _employeeRepo.Get((int)id);
			return View(emp);
		}

		[HttpPost]
		public string Update(Employee emp)
		{
			LogRequestInfo();
			_employeeRepo.Update(emp);
			_logger.LogInformation($"Record with id = {emp.Id} updated");

			return "Запись " + emp.Id + " изменена!";
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			LogRequestInfo();
			var errAction = NullChecker(id);
			if (errAction != null)
				return errAction;

			var emp = _employeeRepo.Get((int)id);
			return View(emp);
		}
		[HttpPost, ActionName("Delete")]
		public string DeleteById(int? id)
		{
			LogRequestInfo();
			_employeeRepo.Remove((int)id);
			_logger.LogInformation($"Record with id = {id} deleted");
			return $"Записи по id ({id}) удалена";
		}

		private void LogRequestInfo() => _logger.LogInformation("{0} request for uri [{1}]", Request.Method, Request.Path.ToString());

		private IActionResult NullChecker(int? id)
		{
			if (id == null)
				return RedirectToAction("Index");

			var emp = _employeeRepo.Get((int)id);
			if (emp == null)
				return new ContentResult
				{
					Content = $"Записи по данноум id ({id}) нет"
				};
			return null;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
