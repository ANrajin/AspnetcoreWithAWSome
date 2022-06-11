using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DynamoDBExample.Entities;
using DynamoDBExample.Repositories;

namespace DynamoDB.Repositories
{
    public class ProductRepository : IRepository
    {
        private readonly DynamoDBContext _context;

        public ProductRepository(AmazonDynamoDBClient client)
        {
            _context = new DynamoDBContext(client);
        }

        public async Task Delete(int Id)
        {
            await _context.DeleteAsync<Products>(Id);
            Console.WriteLine("Product successfully deleted!");
        }

        public async Task<Products> Read(int Id)
        {
            Console.WriteLine($"Fetching Product by Id: {Id}...");
            return await _context.LoadAsync<Products>(Id);
        }

        public async Task<IList<Products>> ReadBatch(IList<int> Id)
        {
            Console.WriteLine("Fetching products...");

            var batch = _context.CreateBatchGet<Products>();

            foreach(var productId in Id)
            {
                batch.AddKey(productId);
            }

            await batch.ExecuteAsync();

            return batch.Results;
        }

        public async Task StoreAsync(Products products)
        {
            await _context.SaveAsync(products);
        }

        public async Task StoreBatchAsync(IList<Products> products)
        {
            var batch = _context.CreateBatchWrite<Products>();
            batch.AddPutItems(products);

            Console.WriteLine("Performing batch write;");

            await batch.ExecuteAsync();
        }
    }
}
