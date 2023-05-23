using Microsoft.AspNetCore.Mvc;
using MvcAWSPostgresEC2.Models;
using MvcAWSPostgresEC2.Repositories;

namespace MvcAWSPostgresEC2.Controllers {
	public class DepartamentoController : Controller {

		private RepositoryDepartamento repo;

		public DepartamentoController(RepositoryDepartamento repo) {
			this.repo = repo;
		}

		public async Task<IActionResult> Index() {
			List<Departamento> list = await this.repo.GetDepartamentosAsync();
			return View(list);
		}

		public async Task<IActionResult> Details(int id) {
			Departamento dept = await this.repo.FindDepartamento(id);
			return View(dept);
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Departamento dept) {
			await this.repo.InsertDepartamento(dept.Nombre, dept.Localidad);
			return RedirectToAction("Index");
		}
	}
}
