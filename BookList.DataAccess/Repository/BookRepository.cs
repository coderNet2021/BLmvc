using BookList.DataAccess.Data;
using BookList.DataAccess.Models;
using BookList.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Book> GetName()
        {
            return await _db.Books.FirstOrDefaultAsync();
        }


        
        
    }
}
