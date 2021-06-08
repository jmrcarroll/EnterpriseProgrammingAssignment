using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EnterpriseProgrammingAssignment.Models
{
    public enum Category { M,N,L}
    public class Car
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Car make is a Required Field")]
        [DisplayName("Car Make")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Car model is a Required Field")]
        [DisplayName("Car Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Category is a Required Field")]
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Purchase Date is a Required Field")]
        [DataType(DataType.Date)]
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "MOT is a Required Field")]
        [DataType(DataType.Date)]
        [DisplayName("MOT Expiry Date")]
        public DateTime MOTExpDate { get; set; }
        [Required(ErrorMessage = "Tax is a Required Field")]
        [DataType(DataType.Date)]
        [DisplayName("Tax Expiry Date")]
        public DateTime TaxExpDate { get; set; }
        [Required(ErrorMessage = "Insurance is a Required Field")]
        [DataType(DataType.Date)]
        [DisplayName("Insurance Expiry Date")]
        public DateTime InsuranceExpDate { get; set; }
        [Required(ErrorMessage = "Site is a Required Field")]
        [DisplayName("Site")]
        public int SiteID { get; set; }
        public virtual Site Location { get; set; }
    }
}
