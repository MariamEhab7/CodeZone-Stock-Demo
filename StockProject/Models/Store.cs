using System.ComponentModel.DataAnnotations;

namespace StockProject.Models
{
    public class Store
    {
        public Store()
        {
            this.Items = new HashSet<Item>();
        }

        public int StoreId { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(100, ErrorMessage = "Max length is 150")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(1000, ErrorMessage = "Max length is 1000")]
        public string Address { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
