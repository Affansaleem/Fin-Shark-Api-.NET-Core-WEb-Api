using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interface;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly FinSharkDbContext _context;
        public CommentRepository(FinSharkDbContext context)
        {
            _context=context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel= await _context.Comments.FindAsync(id);
            if(commentModel == null)
            {
                return null;
            }

             _context.Comments.Remove(commentModel);
             await _context.SaveChangesAsync();
             return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
             
        }

        public async Task<Comment?> GetByIdASync(int id)
        {
            var commentModel= await _context.Comments.FirstOrDefaultAsync(x=>x.Id == id);
            if(commentModel == null)
            {
                return null;
            }
            return commentModel;
        }
    }
}