﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
           return _context.Comments.Select(x=> new Comment
           {
               Name = x.Name,
               Description = x.Description,
               CreatedDate = x.CreatedDate,
               CommentID = x.CommentID,
               BlogId = x.BlogId
           }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.CommentID == id);
        }

        public void Remove(Comment entity)
        {
             _context.Remove(entity);
             _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
