using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Question
    {
   
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Title { get; set; }

        [Required]
        public string Body { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Customers? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set creation time

        public ICollection<Comments>? Comments { get; set; } = null; // Navigation property for related comments

    }
}
