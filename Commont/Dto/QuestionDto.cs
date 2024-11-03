using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Commont.Entity;

namespace Commont.Dto
{
    public class QuestionDto
    {

        public int Id { get; set; }

  
        public string Title { get; set; }

   
        public string Body { get; set; }

        public int? UserId { get; set; }

        //public CustomersDto? User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set creation time

        public ICollection<CommentsDto>? Comments { get; set; } // Navigation property for related comments

    }
}
