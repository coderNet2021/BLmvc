using BookList.DataAccess.Models;
using BookList.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Controllers
{
    public class Books2Controller : Controller
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly IBookRepository _repo;
        public Books2Controller(IBookRepository bookRepo)
        {
            _repo = bookRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                //create
                return View(Book);
            }
            //update
            Book = await _repo.FirstOrDefault(u => u.Id == id); //_db.Books.FirstOrDefault(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return View(Book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    //create
                    _repo.Add(Book);
                    //_db.Books.Add(Book);
                }
                else
                {
                    _repo.Update(Book);
                    //_db.Books.Update(Book);
                }
                _repo.Save();
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Book);
        }


    }
}
