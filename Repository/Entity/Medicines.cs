using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity { 
    public class Medicines
    {
        [Key]
       public int Id { get; set; }
        public string NameMedication { get; set; }
        public int AmountOfMedicine { get; set; }
        public int PriceMedicine { get; set; }
        public DateTime DateMedication { get; set; }

        public string? Image {  get; set; }
    
        //public int BuyerCode { get; set;}// קוד קונה


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }


        public int? CustomerId { get; set; }//קוד קונה
        [ForeignKey("CustomerId")]
        public Customers? Customer { get; set; }

        public int RecognizedId { get; set; }
        [ForeignKey("RecognizedId")]
        public Customers Recognized { get; set; } // קוד מוכר

        public string? RMail { get; set; }
}
}
