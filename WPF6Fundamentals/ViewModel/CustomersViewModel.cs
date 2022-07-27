﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WPF6Fundamentals.Command;
using WPF6Fundamentals.Data;
using WPF6Fundamentals.Model;
using static WPF6Fundamentals.Data.CustomerDataProvider;

namespace WPF6Fundamentals.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }
        public bool IsCustomerSelected => SelectedCustomer != null;
        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public async Task LoadAsync()
        {
            if (Customers.Any())
                return;

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }
        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }
        private void MoveNavigation(object? parameter)
            {
            NavigationSide = NavigationSide == NavigationSide.Left
              ? NavigationSide.Right
              : NavigationSide.Left;
            }
        private void Delete(object? parameter)
        {
            if(SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedCustomer is not null;

    }
    public enum NavigationSide
    {
        Left,
        Right
    }

}
