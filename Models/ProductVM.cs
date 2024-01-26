using System.ComponentModel.DataAnnotations;

namespace SecurityDemo.Models
{
    public class ProductVM
    {
        [Key]
        public string ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal Price { get; set; }
    }

}
