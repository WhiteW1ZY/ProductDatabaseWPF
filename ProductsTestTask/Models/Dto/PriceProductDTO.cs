namespace ProductsTestTask.Models.Dto
{
    class PriceProductDTO
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public Decimal Quantity { get; set; }
        public string Model { get; set; }
        public string Sort { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Wight { get; set; }
        public decimal Price { get; set; }
        public DateTime DateChange { get; set; }
    }
}
