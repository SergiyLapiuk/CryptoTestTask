using CryptoTestTask.Models;
using CryptoTestTask.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CryptoTestTask
{
    public partial class CurrencyConverter : Page
    {
        private CurrencyConverterViewModel _viewModel;

        public CurrencyConverter(ObservableCollection<Asset> coins)
        {
            InitializeComponent();
            _viewModel = new CurrencyConverterViewModel(coins);
            DataContext = _viewModel;
        }

        private void ConvertButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.Convert();
        }
    }
}
