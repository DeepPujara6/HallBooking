using System.ComponentModel.DataAnnotations;

namespace HallBooking.Areas.MST_Hall.Models
{
    public class HallModel
    {
        [Key]
        public int? HallID { get; set; }


        [Required]
        [StringLength(100)]
        public string HallName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string HallDescription { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int PricePerDay { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Deposit { get; set; }

        [StringLength(300)]
        public string LocationURL { get; set; }
        public string? ImageURL { get; set; }

        [Required]
        public int FloorNo { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Select Hall")]

        public int? MCID { get; set; }
        public string? MCName { get; set; }

        public IFormFile? File { get; set; }

    }
}
