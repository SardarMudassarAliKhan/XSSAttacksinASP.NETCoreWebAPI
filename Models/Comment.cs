using System.ComponentModel.DataAnnotations;

namespace XSSAttacksinASP.NETCoreWebAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Comment cannot be longer than 500 characters.")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
