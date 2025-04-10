using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
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
        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await context.Comment.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteCommentAsync(int CommentId)
        {
            var comment = await context.Comment.FindAsync(CommentId);
            if (comment == null) return null;
            context.Comment.Remove(comment);
            await context.SaveChangesAsync();
            return comment;
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

        public async Task<Comment?> UpdateCommentAsync(Comment comment, int CommentId)
        {
            var commentmodel = await context.Comment.FindAsync(CommentId);
            if (commentmodel == null) return null;
            commentmodel.Title = comment.Title;
            commentmodel.Content = comment.Content;
            await context.SaveChangesAsync();
            return comment;
        }
    }
}