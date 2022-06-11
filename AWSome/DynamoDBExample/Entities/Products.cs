using Amazon.DynamoDBv2.DataModel;

namespace DynamoDBExample.Entities
{
    [DynamoDBTable("Rajin-Products")]
    public class Products
    {
        [DynamoDBHashKey]
        public int Id { get; set; }

        [DynamoDBProperty]
        public string Title { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; }

        [DynamoDBProperty]
        public int Price { get; set; }
    }
}
