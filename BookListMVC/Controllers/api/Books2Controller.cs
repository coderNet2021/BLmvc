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

        [HttpGet]
        [Route("GetOneById")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Json(new { data = await _repo.FirstOrDefault(u=>u.Id==id) });
        }

        [HttpGet]
        [Route("GetOneByName")]
        public async Task<IActionResult> GetOneName(string name)
        {
            return Json(new { data = await _repo.FirstOrDefault(u => u.Name == name) });
        }
    }
}
