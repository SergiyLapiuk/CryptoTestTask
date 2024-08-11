using CryptoTestTask.Models;
using CryptoTestTask.Services;
using CryptoTestTask.ViewModels;
using System.Windows;
using System.Windows.Navigation;

namespace CryptoTestTask
{
    public partial class CoinInformation : Window
    {
        public CoinInformation(Asset selectedCoin)
        {
            InitializeComponent();

            var cryptoApiService = new CryptoApiService(); 
            DataContext = new CoinInformationViewModel(selectedCoin, cryptoApiService);
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }
    }
}
