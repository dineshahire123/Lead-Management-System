using System.ComponentModel.DataAnnotations;

namespace LeadManagementSystem.Models
{
    public class LeadActivity
    {
         //Lead Activity Data

        public int Id { get; set; }

        [Required]
        public int LeadId { get; set; }

        [Required(ErrorMessage = "Please select an interaction type.")]
        public string InteractionType { get; set; }

        [Required(ErrorMessage = "Please provide details for the activity.")]
        public string Details { get; set; }

        public Lead Lead { get; set; }
    }
}
