using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class Product
    {
       
        public int Id { get; set; }

        
        public string UniqueNumber { get; set; } = GenerateUniqueId();

        
        public string Name { get; set; }

        public string Description { get; set; }

       
        public decimal Price { get; set; }

       
        public int Stock { get; set; }

        private static string GenerateUniqueId()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}