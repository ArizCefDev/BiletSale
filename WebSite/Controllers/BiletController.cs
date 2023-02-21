using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [Authorize]
    public class BiletController : Controller
    {
        private readonly IBiletService _biletService;

        public BiletController(IBiletService biletService)
        {
            _biletService = biletService;
        }

        [HttpGet("Bilet/Get/{id}")]
        public IActionResult Details()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(CartDTO dto)
        {
            bool isSuccess;
            string mes;
            try
            {
                dto.UserId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

                _biletService.AddToCart(dto);
                mes = "Bilet alındı!";
                isSuccess = true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                isSuccess = false;
            }

            return RedirectToAction("Get",
                new
                {
                    id = dto.BiletId,
                    message = mes,
                    isSuccess = isSuccess
                });
        }

    }
}
