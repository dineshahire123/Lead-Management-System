using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LeadManagementSystem.Models
{

      [Table("Leads")]
    public class Lead
    {

      //Lead Data

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } ="";

        [Required(ErrorMessage = "Organization is required.")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Source of lead is required.")]
        public string Source { get; set; }


        public virtual ICollection<LeadActivity> LeadActivities { get; set; }
    }
}
