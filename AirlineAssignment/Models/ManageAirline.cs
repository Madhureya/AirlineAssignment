using System.ComponentModel.DataAnnotations;

namespace AirlineAssignment.Models
{
    public class ManageAirline
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string AirlineName { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string FromCity { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string ToCity { get; set; }

        [Required]
        public int Fare { get; set; }
    }
}
