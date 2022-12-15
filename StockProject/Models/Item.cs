using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(150, ErrorMessage ="Max length is 150")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "*")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "*")]
        public double Price { get; set; }

       // public DateTime DateOfpurchase { get; set; } = DateTime.Now;

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}
