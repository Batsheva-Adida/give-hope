using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commont.Entity;

namespace Commont.Dto
{
    public class CommentsDto
    {
        [Key]
        public int Id { get; set; }

        public int QuestionId { get; set; }
        //public QuestionDto? Question { get; set; }//השאלה שנשאלה

        public int UserId { get; set; }
    
        //public CustomersDto? User { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set creation time

    }
}
