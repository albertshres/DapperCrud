//Fifth step
using DapperCrudYtb.Models;
using DapperCrudYtb.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudYtb.Controllers
{
    public class BikeController : Controller
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bikes = await _bikeRepository.GetAllAsync();
            return View(bikes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bike = await _bikeRepository.GetByIdAsync(id);
            return bike != null ? View(bike) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                await _bikeRepository.CreateAsync(bike);
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bike = await _bikeRepository.GetByIdAsync(id);
            return bike != null ? View(bike) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                await _bikeRepository.UpdateAsync(bike);
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bike = await _bikeRepository.GetByIdAsync(id);
            return bike != null ? View(bike) : NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bikeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

