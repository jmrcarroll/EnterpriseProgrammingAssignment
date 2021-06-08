using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseProgrammingAssignment.Models
{
    public class Site
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Address is required field")]
        public string Address { get; set; }
        [DisplayName("Post Code")]
        [Required(ErrorMessage = "Post Code is required field")]
        public string PostCode { get; set; }
        [DisplayName("Manger's Name")]
        [Required(ErrorMessage = "Manager Name is required field")]
        public string ManagerName { get; set; }
        [DisplayName("Contact E-mail")]
        [Required(ErrorMessage = "E-mail is required field")]
        public string Email { get; set; }
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "Contact Number is required field")]
        public string ContactNum { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
