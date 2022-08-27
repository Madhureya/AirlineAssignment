using System.ComponentModel.DataAnnotations;

namespace AirlineAssignment.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public string PAN_Number {get; set;}

        [Required]
        public int    status { get; set;}



    }
}
