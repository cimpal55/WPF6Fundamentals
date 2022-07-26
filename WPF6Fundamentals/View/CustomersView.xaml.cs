using System.Windows;
using System.Windows.Controls;
using WPF6Fundamentals.Data;
using WPF6Fundamentals.ViewModel;

namespace WPF6Fundamentals.View
{
    /// <summary>
    /// Логика взаимодействия для CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_LoadedAsync;
        }

        private async void CustomersView_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void btnMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveNavigation();
        }
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }

    }
}
