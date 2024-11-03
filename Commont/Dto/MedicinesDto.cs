using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Commont.Dto
{
    public class MedicinesDto
    {
        public int? Id { get; set; }
        public string NameMedication { get; set; }
        public int AmountOfMedicine { get; set; }
        public int PriceMedicine { get; set; }
        public DateTime DateMedication { get; set; }

        public string? Image { get; set; }
        public int? RecognizedId { get; set; } // קוד מוכר
        public IFormFile? FileImage { get; set; }
        public int? CustomerId { get; set; }// קוד קונה
        public int CategoryId { get; set; }
        public string? RMail { get; set;}
        //  public Customers CodeCustomers { get; set; }

    }
}
