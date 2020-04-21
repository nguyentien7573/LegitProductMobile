using iConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iConnect.Services
{
    public class CategoryDataStore : IDataStore<Category>
    {
        readonly List<Category> categories;
        public CategoryDataStore()
        {
            categories = new List<Category>()
            {
                new Category { Id = Guid.NewGuid().ToString(), Name = "Giày", Description="This is an item description.",Icon = "\ue903",Color ="#dc7d6b" },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Áo", Description="This is an item description.",Icon = "\ue902",Color ="#b5c5d5" },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Quần", Description="This is an item description.",Icon = "\ue901",Color ="#c4dbd1" },
                new Category { Id = Guid.NewGuid().ToString(), Name = "Phụ kiện", Description="This is an item description." ,Icon = "\ue900",Color ="#a59aaa"},
            };
        }
        public async Task<bool> AddItemAsync(Category item)
        {
            categories.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category item)
        {
            var oldItem = categories.Where((Category arg) => arg.Id == item.Id).FirstOrDefault();
            categories.Remove(oldItem);
            categories.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = categories.Where((Category arg) => arg.Id == id).FirstOrDefault();
            categories.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}
