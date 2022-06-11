using DynamoDBExample.Entities;

namespace DynamoDBExample.Repositories
{
    public interface IRepository
    {
        public Task StoreAsync(Products products);

        public Task StoreBatchAsync(IList<Products> products);

        public Task<Products> Read(int Id);

        public Task<IList<Products>> ReadBatch(IList<int> Id);

        public Task Delete(int Id);
    }
}
