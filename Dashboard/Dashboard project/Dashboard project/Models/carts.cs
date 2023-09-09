using System.ComponentModel.DataAnnotations;

namespace Dashboard_project.Models
{
    public class carts
    {
        [Key]
        public int Id { get; set; }
        public string IdCostumer { get; set; }
        public int MyProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double Total { get; set; }
        public string Color { get; set; }
        public int Qty { get; set; }
        public int Capacity { get; set; }




    }
}
