using System.ComponentModel.DataAnnotations;

namespace UserInterface.ViewModels
{
    public class SimpleViewModel
    {
        // A simple Id 
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string Notes { get; set; }
    }

}
