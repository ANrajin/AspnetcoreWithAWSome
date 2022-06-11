using Amazon.DynamoDBv2;
using DynamoDB.Repositories;
using DynamoDBExample.Entities;
using DynamoDBExample.Repositories;

namespace DynamoDB
{
    public class DynamoDbOperations
    {
        public static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        private readonly IRepository _repository;

        public DynamoDbOperations()
        {
            _repository = new ProductRepository(client);
        }

        public async Task GetProduct()
        {
            var product1 = await _repository.Read(101);

            Console.WriteLine($"Id: {product1.Id}");
            Console.WriteLine($"Name: {product1.Title}");
            Console.WriteLine($"Price: {product1.Price}");
        }

        public async Task GetBatchProducts()
        {
            IList<int> productsId = new List<int>()
            {
                101, 102, 103, 104, 105, 106, 107, 108, 109, 110
            };

            var result = await _repository.ReadBatch(productsId);

            foreach(var product in result)
            {
                Console.WriteLine($"{product.Id} Name: {product.Title} || Price: {product.Price}");
            }
        }

        public async Task StoreProductsAsync()
        {
            Products products = new Products()
            {
                Id = 1001,
                Title = "Redmi Note7",
                Description = "Lorem Ipsum",
                Price = 15000
            };

            await _repository.StoreAsync(products);

            Console.WriteLine($"{products.Title} succesfully inserted");
        }

        public async Task StoreBatchProductsAsync()
        {
            IList<Products> products = ProductsList.GetProducts;
            await _repository.StoreBatchAsync(products);

            Console.WriteLine("Successfully Inserted");
        }

        public void DeleteProduct()
        {
            _repository.Delete(1001);
        }
    }
}
