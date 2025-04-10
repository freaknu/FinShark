using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace api.Controllers
{
    [Route("/api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IcommentRepository commentrepo;
        private readonly IStockRepository stockrepo;
        public CommentController(IcommentRepository commentrepo, IStockRepository stockrepo)
        {
            this.commentrepo = commentrepo;
            this.stockrepo = stockrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var comments = await commentrepo.GetAllCommentsAsync();
                if (comments == null || !comments.Any()) return NotFound("No comments found.");

                var commentDTOs = comments.Select(st => st.ToCommentsDTO());
                return Ok(commentDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var comment = await commentrepo.GetByIdAsync(id);
                if (comment == null)
                    return NotFound();
                return Ok(comment.ToCommentsDTO());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> PostComment([FromRoute] int stockId, [FromBody] CreateCommentDTO commentdata)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (!await stockrepo.StockExists(stockId))
                {
                    return BadRequest("Stock Doesnot exists");
                }

                var commentModel = commentdata.ToComment(stockId);
                await commentrepo.AddCommentAsync(commentModel);
                return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentsDTO());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut("{stockId:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] CreateCommentDTO commendata)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Comment commentadata = await commentrepo.UpdateCommentAsync(commendata.ToCommentUpdate(), commentId);
                if (commendata == null)
                {
                    return BadRequest("Comment Didn't Found");
                }
                return Ok(commendata);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpDelete("{commentId:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int commentId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                Comment comment = await commentrepo.DeleteCommentAsync(commentId);
                if (comment == null)
                {
                    return NotFound("Comment Didn't Found");
                }
                return Ok(comment);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}