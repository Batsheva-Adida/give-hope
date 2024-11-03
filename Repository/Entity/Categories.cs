using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Categories
    {
        [Key] 
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public ICollection<Medicines> MedicinesInCategory { get; set; }

    }
}
