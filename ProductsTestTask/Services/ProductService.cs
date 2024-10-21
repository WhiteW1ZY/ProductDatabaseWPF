using Microsoft.EntityFrameworkCore;
using ProductsTestTask.database;
using ProductsTestTask.Models;
using ProductsTestTask.Models.Dto;

namespace ProductsTestTask.Services
{
    class ProductService
    {
        private ApplicationContext _context;

        public ProductService()
        {
            _context = new ApplicationContext();
        }

        public enum ProductFilterEnum 
        { 
            ByAllFields = 0,
            ByCodeField,
            ByNameField,
            ByBarCodeField,
            ByPriceField
        }

        public void GenerateALotOfLines(int count = 1000)
        {
            Random rand = new Random();

            string[] names = ["leonid", "ekaterina", "kristina", "sofia", "maxim", "innokentiy", "eduard", "vasilya", "vasiliy", "michael", "gogol"];
            string[] barcodes = ["awdfsrgad", "desbdmfcm", "dwmbsfm", "dwmvsfmawad,fe", "dwensbkjnadw", "denrsdn", "dwmsod", "dwpgsmd", "KMbrskfjxnvda"];
            string[] colors = ["blue", "red", "yellow", "green", "violet", "yellow"];
            string[] models = ["new", "oldest", "first", "second", "third", "fourth", "fifth", "sixth"];
            string[] sorts = ["high", "low", "medium"];
            string[] sizes = ["xs", "s", "m", "l", "xl", "xxl"];

            for (int i = 0; i < count; i++) 
            {
                var cost = rand.Next(1000000);
                var price = _context.Price.SingleOrDefault(p => p.Price == cost);
                if (price is null)
                {
                    price = new Cost { Price = cost };
                }

                _context.Products.Add(
                    new Product
                    {
                        Wight = rand.Next(10000).ToString(),
                        Quantity = rand.Next(100000),
                        Sort = sorts[rand.Next(sorts.Length-1)],
                        Size = sizes[rand.Next(sizes.Length-1)],
                        Price = price,
                        Name = names[rand.Next(names.Length - 1)],
                        Model = models[rand.Next(models.Length - 1)],
                        Color = colors[rand.Next(colors.Length - 1)],
                        Code = rand.Next(1000000),
                        BarCode = barcodes[rand.Next(barcodes.Length - 1)],
                        DateChange = DateTime.Now.AddDays(-rand.Next(100000)),
                    });
            }

            _context.SaveChanges();
            
        }

        public ICollection<PriceProductDTO> GetProducts(
            ProductFilterEnum productFilter = ProductFilterEnum.ByAllFields,
            string searchText = "")
        {
            searchText = searchText.ToLower();

            var products = _context.Products
                .Include(p => p.Price)
                .Select(p => new PriceProductDTO
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                BarCode = p.BarCode,
                Quantity = p.Quantity,
                Model = p.Model,
                Sort = p.Sort,
                Color = p.Color,
                Size = p.Size,
                Wight = p.Wight,
                Price = p.Price.Price,
                DateChange = p.DateChange
            });

            switch (productFilter)
            {
                case ProductFilterEnum.ByAllFields:
                    return products.Where(
                        p => p.Id.ToString().Contains(searchText)
                        || p.Code.ToString().ToLower().Contains(searchText)
                        || p.Name.ToLower().Contains(searchText)
                        || p.BarCode.ToLower().Contains(searchText)
                        || p.Quantity.ToString().ToLower().Contains(searchText)
                        || p.Model.ToLower().Contains(searchText)
                        || p.Sort.ToLower().Contains(searchText)
                        || p.Size.ToLower().Contains(searchText)
                        || p.Color.ToLower().Contains(searchText)
                        || p.Wight.ToLower().Contains(searchText)
                        || p.Price.ToString().ToLower().Contains(searchText)
                        || p.DateChange.ToString().ToLower().Contains(searchText)
                        ).ToList();

                case ProductFilterEnum.ByCodeField:
                    return products.Where(p => p.Code.ToString().ToLower().Contains(searchText))
                        .OrderBy(p => p.Code)
                        .ToList();

                case ProductFilterEnum.ByNameField:
                    return products.Where(p => p.Name.ToLower().Contains(searchText))
                        .OrderBy(p => p.Name)
                        .ToList();

                case ProductFilterEnum.ByBarCodeField:
                    return products.Where(p => p.BarCode.ToLower().ToString().Contains(searchText))
                        .OrderBy(p => p.BarCode)
                        .ToList();

                case ProductFilterEnum.ByPriceField:
                    return products.Where(p => p.Price.ToString().ToLower().Contains(searchText))
                        .OrderBy(p => p.Price.ToString())
                        .ToList();

                default: return new List<PriceProductDTO>();
            }
        }

        public Product? GetProductById(Guid id) 
        {
            var product = _context.Products
                .Include(p => p.Price)
                .SingleOrDefault(p => p.Id == id);

            return product;
        }

        public void AddProduct(ProductRaw productRaw)
        {
            var Price = _context.Price.SingleOrDefault(p => p.Price == productRaw.Price);

            if (Price == null) 
            {
                Price = new Cost { Price = productRaw.Price };
            }

            _context.Products.Add(new Product
            {
                BarCode = productRaw.BarCode,
                Name = productRaw.Name,
                Code = productRaw.Code,
                Color = productRaw.Color,
                Model = productRaw.Model,
                Sort = productRaw.Sort,
                Price = Price,
                Quantity = productRaw.Quantity,
                Size = productRaw.Size,
                Wight = productRaw.Wight,
                DateChange = DateTime.Now,
            });

            _context.SaveChanges();
        }

        public void UpdateProduct(Guid productId, ProductRaw productRaw) 
        {
            var product = _context.Products
                .Include(p => p.Price)
                .ThenInclude(p => p.Products)
                .SingleOrDefault(p => p.Id == productId);

            if (product == null) 
            {
                throw new InvalidOperationException();
            }

            var Price = _context.Price.SingleOrDefault(p => p.Price == productRaw.Price);

            if (Price is null)
            {
                Price = new Cost { Price = productRaw.Price };
            }

            product.Code = productRaw.Code;
            product.Name = productRaw.Name;
            product.BarCode = productRaw.BarCode;
            product.Quantity = productRaw.Quantity;
            product.Model = productRaw.Model;
            product.Sort = productRaw.Sort;
            product.Color = productRaw.Color;
            product.Size = productRaw.Size;
            product.Wight = productRaw.Wight;
            product.DateChange = DateTime.Now;
            product.Price = Price;

            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id) 
        {
            var product = _context.Products
                .Include(p => p.Price)
                .ThenInclude(p => p.Products)
                .SingleOrDefault(p => p.Id == id);

            if (product != null) 
            {
                if (product.Price.Products.Count == 1)
                {
                    _context.Price.Remove(product.Price);
                }

                _context.Remove(product);
                _context.SaveChanges();

            }
        }
    }
}
