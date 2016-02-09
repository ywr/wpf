using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCali.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        IWindowManager _windowManager;
        Func<InvoicesListingViewModel> _invoicesListingViewModelLocator;
        Func<OrdersListingViewModel> _ordersListingViewModelLocator;
        public MainViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, Func<InvoicesListingViewModel> invoicesListingViewModelLocator, Func<OrdersListingViewModel> ordersListingViewModelLocator)
        {
            _windowManager = windowManager;
            _invoicesListingViewModelLocator = invoicesListingViewModelLocator;
            _ordersListingViewModelLocator = ordersListingViewModelLocator;
        }


        public bool CanShowInvoices
        {
            get { return true; }
        }

        public void ShowInvoices()
        {
            ActivateItem(_invoicesListingViewModelLocator());

        }

        public void ShowOrders()
        {
            ActivateItem(_ordersListingViewModelLocator());

        }
    }
}
