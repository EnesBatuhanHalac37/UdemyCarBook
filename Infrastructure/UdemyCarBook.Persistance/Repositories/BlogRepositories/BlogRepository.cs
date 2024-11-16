using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInderfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogWithAuthorAsync()
        {
           var values = await _context.Blogs.Include(x=>x.Author).ToListAsync();
            return values;
        }

        public async Task<Blog> GetAuthorByBlogIdAsync(int id)
        {
            var value = await _context.Blogs.Include(y=>y.Author).FirstOrDefaultAsync(x => x.BlogID == id);
            return value;
        }

        public async Task<List<Blog>> GetLast3BlogWithAuthors()
        {
            var values = await _context.Blogs.Include(b=>b.Author).OrderByDescending(x=>x.BlogID).Take(3).ToListAsync();
            return values;
        }
    }
}
