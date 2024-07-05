using System.ComponentModel.DataAnnotations;
namespace HallBooking.Areas.MST_Corporation.Models
{
    public class CorporationModel
    {
        public int? UserID { get; set; }

        [Key]
        public int? MCID { get; set; }

        [Required]
        [StringLength(200)]
        public string MCName { get; set; }

        [StringLength(20)]
        public string MCCity { get; set; }

        public int MCPinCode { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? MCLogo { get; set; }
        [Required]
        public string? MCEmail { get; set; }
        [Required]
        public string? ContactPerson { get; set; }
        [Required]
        public string? ContactNo { get; set; }
        [Required]
        public string? MCAddress { get; set; }
        public IFormFile? File { get; set; }
    }
}
