using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Should be Minimum of 5 Characters")]
        [MaxLength(280, ErrorMessage = "Title Shouldnot be Morethan 280 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content Should be Minimum of 5 Characters")]
        [MaxLength(280, ErrorMessage = "Content Shouldnot be Morethan 280 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}