using System;
using System.ComponentModel.DataAnnotations;

namespace wweblog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        // Nếu có model Post thì có thể thêm: public Post Post { get; set; }
    }
}
