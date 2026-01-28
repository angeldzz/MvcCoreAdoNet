using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryHospital repo;

        public DoctoresController()
        {
            this.repo = new RepositoryHospital();
        }

        public async Task<IActionResult> Index()
        {
            List<Doctor> doctores = await this.repo.GetAllDoctoresAsync();
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string especialidad)
        {
            List<Doctor> doctoresFiltrados = await this.repo.GetDoctoresEspecialidadAsync(especialidad);
            return View(doctoresFiltrados);
        }
    }
}
