using System.ComponentModel.DataAnnotations;

namespace HallBooking.Areas.SEC_User.Models
{
    public class SEC_UserLoginModel
    {
        public int? UserID { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(200)]
        public string Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }


}
