using System.ComponentModel.DataAnnotations;

namespace Dashboard_project.Models
{
    public class Invoice
    {

        [Key]
        public int Id { get; set; }
        public string CostumerId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public float Discounts { get; set; }
        public double Total { get; set; }
        public int Capacity { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public DateTime DateTime { get; set; }
    }
}
