using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF6Fundamentals.Model;

namespace WPF6Fundamentals.Data
{
    public interface IProductsDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }

    public class ProductsDataProvider : IProductsDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work

            return new List<Product>
            {
                new Product{Name="Cappucino", Description="Espresso with milk and milk foam"},
                new Product{Name="Doppio", Description="Double espresso"},
                new Product{Name="Espresso", Description="Pure coffee to keep you awake! :-)"},
                new Product{Name="Latte", Description="Espresso with milk and milk foam"},
                new Product{Name="Macchiato", Description="Espresso with milk and milk foam"},
                new Product{Name="Mocha", Description="Espresso with milk and milk foam"}
            };
        }
    }
}
