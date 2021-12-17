using BookList.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListMVC.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books2Controller : Controller
    {
        private readonly IBookRepository _repo;
        public Books2Controller(IBookRepository bookRepo)
        {
            _repo = bookRepo;
        }
        [HttpGet]
        [Route("getAll2")]
        public async Task<IActionResult> GetAll2()
        {
            return Json(new { data = await _repo.FindAll() });
        }
    }
}
