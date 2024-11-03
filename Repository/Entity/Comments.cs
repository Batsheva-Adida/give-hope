using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Comments
    {

        [Key]
        public int Id { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }//השאלה שנשאלה

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Customers? User { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set creation time

    }
}
