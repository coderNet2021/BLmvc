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
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Books.ToListAsync() });
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
