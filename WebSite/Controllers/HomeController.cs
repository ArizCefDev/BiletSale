using Business.Abstract;
using DataAccess;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBiletService _biletService;
        private readonly ApplicationDbContext _context;

        public HomeController(IBiletService biletService, ApplicationDbContext context)
        {
            _biletService = biletService;
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null)
        {
            //Search
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;


            //Sorting
            int allProductsCount;
            var res = _biletService.GetFilter(out allProductsCount, page, pageSize, order, search);

            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }
            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }


            ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
            ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;


            var pagedRs = new PagedResponseDTO<BiletDTO>(page, pageSize, res);

            ViewBag.BiletCount = _context.Bilets.Count();
            return View(pagedRs);
        }

        [HttpGet]
        public IActionResult GetCart(string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }

            var userId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

            var res = _biletService.GetCart(userId);

            ViewBag.CartCount = _context.Carts.Count();

            return View(res);

        }


        [HttpPost]
        public IActionResult Buy(PayDTO dto)
        {
            _biletService.Buy(dto.CartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Sifarişiniz qəbul olundu! Qiymət " + dto.Sum + "azn",
                    isSuccess = true
                });
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int cartId)
        {
            _biletService.DeleteFromCart(cartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Sifarişiniz ləgv olundu!",
                    isSuccess = true
                });
        }

        public IActionResult Details(int id)
        {
            var values = _biletService.Get(id);
            return View(values);
        }
    }
}
