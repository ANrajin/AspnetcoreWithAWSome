using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoDBExample.Entities
{
    public static class ProductsList
    {
        public static List<Products> GetProducts { get; } = new List<Products>()
            {
                new Products()
                {
                    Id = 101,
                    Title = "COLMI P28 PLUS Smart Watch with Calling Feature",
                    Description = "Lorem Ipsum",
                    Price = 1999
                },
                new Products()
                {
                    Id = 102,
                    Title = "Redmi 10C 4GB/128GB",
                    Description = "Lorem Ipsum",
                    Price = 14999
                },
                new Products()
                {
                    Id = 103,
                    Title = "realme Narzo 50 4GB/64GB",
                    Description = "Lorem Ipsum",
                    Price = 17999
                },
                new Products()
                {
                    Id = 104,
                    Title = "Nokia 1.4 DS 3GB/64GB",
                    Description = "Lorem Ipsum",
                    Price = 11999
                },
                new Products()
                {
                    Id = 105,
                    Title = "Samsung Galaxy F22 6GB/128GB",
                    Description = "Lorem Ipsum",
                    Price = 20999
                },
                new Products()
                {
                    Id = 106,
                    Title = "OnePlus Bullets Wireless Z Series Bass Edition",
                    Description = "Lorem Ipsum",
                    Price = 2299
                },
                new Products()
                {
                    Id = 107,
                    Title = "Infinix Hot 12 Play 4GB/64GB",
                    Description = "Lorem Ipsum",
                    Price = 12699
                },
                new Products()
                {
                    Id = 108,
                    Title = "realme C31 4GB/64GB",
                    Description = "Lorem Ipsum",
                    Price = 13990
                },
                new Products()
                {
                    Id = 109,
                    Title = "Samsung Galaxy M33 5G 8GB/128GB",
                    Description = "Lorem Ipsum",
                    Price = 30999
                },
                new Products()
                {
                    Id = 110,
                    Title = "vivo V23e 8GB/128GB with Free vivo Backpack",
                    Description = "Lorem Ipsum",
                    Price = 25990
                },
            };
    }
}
