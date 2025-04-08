using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class IcommentRepository : CommentCon
    {
        private readonly ApplicationDBContext context;
        public IcommentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Comment> AddCommentAsync(Comment comment, int StockId)
        {
            var stock = await context.Stock.FirstOrDefaultAsync(st => st.Id == StockId);
            throw new NotImplementedException();

        }

        public Task<Comment?> DeleteCommentAsync(int CommentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await context.Comment.FirstOrDefaultAsync(com => com.Id == id);
            return comment;
        }

        public Task<Comment?> UpdateCommentAsync(int CommentId, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}