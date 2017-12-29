using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //When we want to customize the error message we need to add the property in required attribute.
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}