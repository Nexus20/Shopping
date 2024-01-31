using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data;

public class ProductContext
{
    private readonly IMongoCollection<Product> _products;
    
    public ProductContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        _products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
        SeedData();
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _products.Find(p => true).ToListAsync();
    }
    
    private void SeedData()
    {
        if (!_products.Find(p => true).Any())
        {
            _products.InsertMany(PreconfiguredProducts);
        }
    }
    
    private static readonly List<Product> PreconfiguredProducts =
    [
        new Product()
        {
            Name = "IPhone X",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = "Smart Phone"
        },

        new Product()
        {
            Name = "Samsung 10",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = "Smart Phone"
        },

        new Product()
        {
            Name = "Huawei Plus",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Category = "White Appliances"
        },

        new Product()
        {
            Name = "Xiaomi Mi 9",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Category = "White Appliances"
        },

        new Product()
        {
            Name = "HTC U11+ Plus",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Category = "Smart Phone"
        },

        new Product()
        {
            Name = "LG G7 ThinQ EndofCourse",
            Description =
                "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = "Home Kitchen"
        }
    ];
}