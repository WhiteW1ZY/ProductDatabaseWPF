namespace ProductsTestTask.Models
{
    class Cost
    {
        public Guid Id { get; set; }
        public Decimal Price { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
