using OnlineLibrary.Data;
using OnlineLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace OnlineLibrary.Controllers
{
    public class RegistrationController : Controller
    {
        private OnlineLibraryDbContext dtbs;

        public RegistrationController(OnlineLibraryDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegisteredReader registeredReader)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = dtbs.Database.BeginTransaction())
                {
                    try
                    {
                        bool usExist = dtbs.RegisteredReaders.Any(p => p.e_mail == registeredReader.e_mail);

                        if (!usExist)
                        {
                            dtbs.RegisteredReaders.Add(registeredReader);
                            dtbs.SaveChanges();

                            RegisteredReader newReader = dtbs.RegisteredReaders.FirstOrDefault(p => p.e_mail == registeredReader.e_mail);

                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }                              
            }
            return RedirectToAction("Login", "Login");
        }
    }
}