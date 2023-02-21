using Business.Abstract;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO dto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Create(dto);

                    ViewBag.Success = "Hesabınız yarandı";
                    return View(dto);
                }
                else
                    return View(dto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //    RedirectToAction("Index", "Web");

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO dto)
        {
            try
            {
                var user = _userService.Login(dto);

                Authenticate(user);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }

        //Cookie
        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.RoleName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
