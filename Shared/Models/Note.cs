using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazing_notes.Shared.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage="Title is too long")]
        public string? Title { get; set; }
        [Required]
        public string?  Content { get; set; }
        public virtual List<Tag>? Tags { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string?  Description { get; set; }
        public DateTime Added { get; set; }
    }
}