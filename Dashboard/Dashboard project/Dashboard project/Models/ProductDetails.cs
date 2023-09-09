using System.ComponentModel.DataAnnotations;

namespace Dashboard_project.Models
{
    public class ProductDetails
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public int Qty { get; set; }
        public string Deisplay { get; set; }
        public string color { get; set; }
        public string? Image { get; set; }
        public int Capacity { get; set; }
        public string MoreDetails { get; set; }



    }
}
