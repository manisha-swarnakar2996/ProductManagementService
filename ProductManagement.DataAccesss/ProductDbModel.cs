using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Models
{
    public class ProductDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UniqueNumber { get; set; } = GenerateUniqueId();

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        private static string GenerateUniqueId()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}