using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentsDTO(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToComment(this CreateCommentDTO commentmodel, int stockid)
        {
            return new Comment
            {
                Title = commentmodel.Title,
                Content = commentmodel.Content,
                StockId = stockid
            };
        }

        public static Comment ToCommentUpdate(this CreateCommentDTO commentmodel)
        {
            return new Comment
            {
                Title = commentmodel.Title,
                Content = commentmodel.Content
            };
        }
    }
}