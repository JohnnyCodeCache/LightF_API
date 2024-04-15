using LightF_API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LightF_API.Models
{
    public class SupervisorNotification
    {
        [Required]
        [OnlyAlphabetic]
        public string FirstName { get; set; }

        [Required]
        [OnlyAlphabetic]
        public string LastName { get; set; }

        [EmailOrBlank]
        public string Email { get; set; }

        [PhoneNumberOrBlank]
        public string PhoneNumber { get; set; }

        [Required]
        public string Supervisor { get; set; }
    }
}
