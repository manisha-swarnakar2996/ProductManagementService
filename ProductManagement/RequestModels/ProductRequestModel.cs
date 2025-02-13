    namespace ProductManagement.RequestModels;
    public class ProductRequestModel
    {

        public int Id { get; set; }


        public string UniqueNumber { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }


        public decimal Price { get; set; }


        public int Stock { get; set; }

    }
