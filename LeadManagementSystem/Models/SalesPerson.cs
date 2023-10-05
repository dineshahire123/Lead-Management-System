// Models/SalesPerson.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LeadManagementSystem.Models
{
   [Table("SalesPerson")]
    public class SalesPerson
    {

           //Sales Persons Data

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeeId { get; set; }        

    }
}
