using OnlineLibrary.Data;
using OnlineLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineLibrary.Controllers
{
    public class LoginController : Controller
    {
        private OnlineLibraryDbContext dtbs;

        public static bool IsAdmin = false;

        public LoginController(OnlineLibraryDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisteredReader registeredReader)
        {
            // Перевірка чи існує користувач із введеними ім'ям та паролем
            var Reader = dtbs.RegisteredReaders.FirstOrDefault(v => v.e_mail == registeredReader.e_mail && v.password == registeredReader.password);

            if (Reader != null)
            {
                // Користувач знайдений, перенаправляємо його на головну сторінку
                ProfileController.RegisteredReader = Reader;
                HttpContext.Session.SetString("Username", registeredReader.e_mail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неправильне ім'я користувача або пароль");
                ModelState.AddModelError(string.Empty, "Або Ваш акаунт не є зареєстрований");
                return View();
            }

        }

        
        [HttpPost]
        public IActionResult AdminLogin(Admin admin)
        {
            // Перевірка чи існує користувач із введеними ім'ям та паролем
            var adminUser = dtbs.Admin.FirstOrDefault(v => v.Email == admin.Email && v.Password == admin.Password);

            if (adminUser != null)
            {
                // Користувач знайдений, перенаправляємо його на головну сторінку
                ProfileController.admin = adminUser;
                IsAdmin = true;
                HttpContext.Session.SetString("Username", admin.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неправильне ім'я користувача або пароль");
                ModelState.AddModelError(string.Empty, "Або Ваш акаунт не є зареєстрований");
                return View();
            }

        }
    }
}