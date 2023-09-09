using System.ComponentModel.DataAnnotations;

namespace Dashboard_project.Models
{
    public class customer
    {

        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerRegion { get; set; }
    }
}
