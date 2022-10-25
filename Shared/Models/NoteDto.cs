using System.ComponentModel.DataAnnotations;

namespace blazing_notes.Shared.Models
{
    public class NoteDto
    {
        [Required]
        [StringLength(50, ErrorMessage="Title is too long")]
        public string? Title { get; set; }
        [Required]
        public string?  Content { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}