using Business;
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
            try
            {
                if (ModelState.IsValid)
                {
                    _biletService.Create(p);
                    return RedirectToAction("AdminIndex");
                }
                else
                    return View(p);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
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
            try
            {
                if (ModelState.IsValid)
                {
                    _biletService.Update(p);
                    return RedirectToAction("AdminIndex");
                }
                else
                    return View(p);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult AdminBiletDelete(int id)
        {
            _biletService.Delete(id);
            return RedirectToAction("AdminIndex");
        }
    }
}