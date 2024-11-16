using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.BlogInderfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogWithAuthors();
        Task<List<Blog>> GetAllBlogWithAuthorAsync();
        Task<Blog> GetAuthorByBlogIdAsync(int id);
    }
}
