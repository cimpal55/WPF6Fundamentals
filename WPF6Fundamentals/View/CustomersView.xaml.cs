using System.Windows;
using System.Windows.Controls;

namespace WPF6Fundamentals.View
{
    /// <summary>
    /// Логика взаимодействия для CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }
        private void btnMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            //var newColumn = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            var column = Grid.GetColumn(customerListGrid);

            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, newColumn);
        }

    }
}
