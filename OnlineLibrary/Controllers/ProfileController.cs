using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Models;
using OnlineLibrary.Data;
using System.Transactions;

namespace OnlineLibrary.Controllers;

public class ProfileController : Controller
{
    public static Admin? admin;
    public static RegisteredReader? RegisteredReader;

    private OnlineLibraryDbContext dtbs;

    public ProfileController(OnlineLibraryDbContext dtbs)
    {
        this.dtbs = dtbs;

    }

    public IActionResult Profile()
    {
        return View();
    }

    public IActionResult LogOut()
    {
        RegisteredReader = null;
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AdminLogOut()
    {
        admin = null;
        LoginController.IsAdmin = false;
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }



    public IActionResult EditProfile()
    {
        return View();
    }

    public IActionResult HistoryOfReadBooks()
    {
        var historyofread = dtbs.HistoryOfReadBooks.Where(o => o.RegisteredReaders.id == RegisteredReader.id).ToList();
        var booktohis = dtbs.Books.ToList();

        var viewModel = new BooksAndReaders
        {
            hisofreadlist = historyofread,
            bookforhislist = booktohis
        };
        return View(viewModel);
    }

    public IActionResult EditDoneProfile(string newFirstName, string newSurname, string newEmail, string newFaculty, string newSpecialty)
    {
        if (RegisteredReader != null)
        {
            using (var transaction = dtbs.Database.BeginTransaction())
            {
                try
                {
                    RegisteredReader.first_name = newFirstName;
                    RegisteredReader.surname = newSurname;
                    RegisteredReader.e_mail = newEmail;
                    RegisteredReader.faculty = newFaculty;
                    RegisteredReader.specialty = newSpecialty;
                    dtbs.Update(RegisteredReader);
                    dtbs.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            return RedirectToAction("Profile");
        }

        return View();
    }

    public IActionResult DeleteProfile()
    {
        using (var transaction = dtbs.Database.BeginTransaction())
        {
            try
            {
                dtbs.RegisteredReaders.Remove(RegisteredReader);
                RegisteredReader = null;
                dtbs.SaveChanges();
                HttpContext.Session.Clear();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }            
            return RedirectToAction("Index", "Home");
        }
    }
    [HttpPost]
    public ActionResult BookinhistoryDelete(int bookId)
    {
        using (var transaction = dtbs.Database.BeginTransaction())
        {
            try
            {
                HistoryOfReadBooks deletedBook = new HistoryOfReadBooks();
                deletedBook = dtbs.HistoryOfReadBooks.Find(bookId);
                dtbs.HistoryOfReadBooks.Remove(deletedBook);
                dtbs.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
            return RedirectToAction("HistoryOfReadBooks", "Profile");
        }
        
        
    }
}

