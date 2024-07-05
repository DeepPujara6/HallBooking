using System.ComponentModel.DataAnnotations;

namespace HallBooking.Models
{
	public class UserModel
	{
		[Key]
		public int? BookingID { get; set; }

		[Required]
		public int UserID { get; set; }

		[Required]
		public int? HallID { get; set; }

		public DateTime? Date { get; set; }

		[Required]
		public DateTime FromDate { get; set; }

		[Required]
		public DateTime ToDate { get; set; }

		[Required]
		public int Persons { get; set; }

		[Required]
		[StringLength(250)]
		public string BookingPurpose { get; set; }

		[Required]
		[StringLength(250)]
		public string CustomerName { get; set; }

		[Required]
		[StringLength(20)]
		public string Mobile { get; set; }

		[StringLength(50)]
		public string Email { get; set; }

		[StringLength(200)]
		public string Address { get; set; }

		[StringLength(20)]
		public string IdProofNo { get; set; }

		[StringLength(300)]
		public string? IdProofPhoto { get; set; }

		public bool? IsPending { get; set; }
		public DateTime? Created { get; set; }

		public DateTime? Modified { get; set; }

		public IFormFile? File { get; set; }

		public int? BookingNo { get; set; }
	}
}
