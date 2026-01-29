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
            List<string> especialidades = await this.repo.GetEspecialidadesAsync();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string especialidad)
        {
            List<Doctor> doctores = await this.repo.GetDoctoresEspecialidadAsync(especialidad);
            List<string> especialidades = await this.repo.GetEspecialidadesAsync();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }
    }
}
