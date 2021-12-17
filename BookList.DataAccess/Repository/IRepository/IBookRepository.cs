using BookList.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.DataAccess.Repository.IRepository
{
    public interface IBookRepository:IRepository<Book>
    {
        Task<Book> GetName();
    }
}
