using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public CommentController(IcommentRepository commentrepo)
        {
            this.commentrepo = commentrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
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
        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
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

    }
}