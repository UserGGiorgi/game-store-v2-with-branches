using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        public CreateCommentDto Comment { get; set; } = new ();

        public Guid? ParentId { get; set; }
        public string? Action { get; set; }
    }
}
