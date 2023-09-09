using System.ComponentModel.DataAnnotations;

namespace Dashboard_project.Models
{
	public class PaymentAccept
	{
		[Key]
        public int id { get; set; }

		[Required]
		public string Payment { get; set; }
    }
}
