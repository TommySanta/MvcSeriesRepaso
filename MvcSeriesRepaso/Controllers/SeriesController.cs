using Microsoft.AspNetCore.Mvc;
using MvcSeriesRepaso.Data;
using MvcSeriesRepaso.Models;
using MvcSeriesRepaso.Repositories;

namespace MvcSeriesRepaso.Controllers
{
    public class SeriesController : Controller
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Serie> series = await this.repo.GetSeriesAsync();
            return View(series);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Serie serie)
        {
            await this.repo.CreateSerieAsync(serie.Nombre, serie.Imagen, serie.Anyo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var serie = await this.repo.FindSerieAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serie = await this.repo.FindSerieAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Serie serie)
        {
            await this.repo.UpdateSerieAsync(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Anyo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteSerieAsync(id);
            return RedirectToAction("Index");
        }

    }
}
