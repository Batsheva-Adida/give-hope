using Commont.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commont.Entity
{
    public class CategoriesDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }


        // public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public ICollection<MedicinesDto> MedicinesInCategory { get; set; }

    }
}
