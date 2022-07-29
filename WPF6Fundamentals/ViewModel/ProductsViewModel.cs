using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WPF6Fundamentals.Data;
using WPF6Fundamentals.Model;

namespace WPF6Fundamentals.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductsDataProvider _productsDataProvider;

        public ProductsViewModel(IProductsDataProvider productsDataProvider)
        {
            _productsDataProvider = productsDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
                return;

            var products = await _productsDataProvider.GetAllAsync();
            if (products != null) 
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }

    }
}
