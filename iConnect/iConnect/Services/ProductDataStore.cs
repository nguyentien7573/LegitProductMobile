using iConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iConnect.Services
{
    public class ProductDataStore : IDataStore<Product>
    {
        readonly List<Product> products;
        public ProductDataStore()
        {
            products = new List<Product>()
            {
                new Product { 
                                Id = Guid.NewGuid().ToString(), 
                                Name = "Adidas EQT", 
                                description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                price = 2000000,
                                productImgeDetail = new List<ProductImgeDetail>
                                    {
                                        new ProductImgeDetail("adidas.png", "#c5c1be"),
                                        new ProductImgeDetail("adidas_eqt_black", "#a6b9d6"),
                                        new ProductImgeDetail("adidas_eqt_black_turbo", "#ea7677")
                                    }
                            },
                new Product { 
                                Id = Guid.NewGuid().ToString(), 
                                Name = "balenciaga", 
                                description="This is an item description.", 
                                price = 3000000,
                                productImgeDetail =  new List<ProductImgeDetail>{new ProductImgeDetail("balenciaga.png", "gray")}
                            },
                new Product { 
                                Id = Guid.NewGuid().ToString(), 
                                Name = "nike", 
                                description="This is an item description.",
                                price = 4000000,
                                productImgeDetail =  new List<ProductImgeDetail>{new ProductImgeDetail("nike.png", "gray")}
                            },
                new Product { 
                                Id = Guid.NewGuid().ToString(), 
                                Name = "adidas", 
                                description="This is an item description.", 
                                price = 1000000,
                                productImgeDetail =  new List<ProductImgeDetail>{new ProductImgeDetail("adidas.png", "gray")}
                            },
            };
        }
        public async Task<bool> AddItemAsync(Product item)
        {
            products.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var oldItem = products.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
            products.Remove(oldItem);
            products.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = products.Where((Product arg) => arg.Id == id).FirstOrDefault();
            products.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return await Task.FromResult(products.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(products);
        }
    }
}
