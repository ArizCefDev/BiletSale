using Business.Abstract;
using DTO.DTOEntity;
using Helper.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]

    public class AdminController : Controller
    {
        private readonly IBiletService _biletService;

        public AdminController(IBiletService biletService)
        {
            _biletService = biletService;
        }

        public IActionResult AdminIndex()
        {
            var values = _biletService.Get();
            return View(values.OrderByDescending(x=>x.Id));
        }

        [HttpGet]
        public IActionResult AdminBiletAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminBiletAdd(BiletDTO p)
        {
            _biletService.Create(p);
            return RedirectToAction("AdminIndex");
        }

        [HttpGet]
        public IActionResult AdminBiletUpdate(int id)
        {
            var values = _biletService.Get(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult AdminBiletUpdate(BiletDTO p)
        {
            _biletService.Update(p);
            return RedirectToAction("AdminIndex");
        }

        public IActionResult AdminBiletDelete(int id)
        {
            _biletService.Delete(id);
            return RedirectToAction("AdminIndex");
        }
    }
}