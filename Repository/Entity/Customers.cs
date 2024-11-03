using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public string CustomersId {get; set; }
        // public List<String> MedicinesForDelivery { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Medicines>? MedicinesToTake { get; set; }

        [InverseProperty("Recognized")]
        public ICollection<Medicines>?  MedicinesToBring { get; set; }

    }
}
