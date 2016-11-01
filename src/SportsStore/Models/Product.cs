namespace SportsStore.Models
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        protected Product()
        {
        }

        public Product(string name, decimal price, string description = null)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public Product(int productId, string name, decimal price) : this(name, price)
        {
            ProductId = productId;
        }

        public override bool Equals(object obj)
        {
            Product p = obj as Product;
            if (p == null) return false;
            return p.ProductId == ProductId;
        }

        public override int GetHashCode()
        {
            //GetHashCode(ProductId) is redundant want de GetHashCode van een int retourneert de int zelf
            return ProductId;
        }
    }
}