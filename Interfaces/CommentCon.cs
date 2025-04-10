using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface CommentCon
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment?> GetByIdAsync(int StockId);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(Comment comment, int CommentId);
        Task<Comment?> DeleteCommentAsync(int CommentId);
    }
}