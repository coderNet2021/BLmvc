using BookList.DataAccess.Repository.IRepository;
using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookListMVC.api
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IBookRepository _repo;
        public BooksController(ApplicationDbContext db,IBookRepository bookRepo)
        {
            _db = db;
            _repo = bookRepo;
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Books.ToListAsync() });
        }

        [HttpGet]
        [Route("getAll2")]
        public async Task<IActionResult> GetAll2()
        {
            return Json(new { data = await _repo.FindAll()});
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Books.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
