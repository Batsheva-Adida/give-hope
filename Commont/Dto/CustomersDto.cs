using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commont.Entity
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }

        public static Task<CustomersDto> GetUserByUserEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        // public int CustomerId { get; set; }
        // public List<String> MedicinesForDelivery { get; set; }
        //  public List<String> MedicinesToTake { get; set; }

    }
}
