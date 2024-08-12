using CryptoTestTask.Models;
using CryptoTestTask.Services;
using CryptoTestTask.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CryptoTestTask
{
    public partial class CoinInformation : Page
    {
        public CoinInformation(Asset selectedCoin)
        {
            InitializeComponent();

            var cryptoApiService = new CryptoApiService();
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            DataContext = new CoinInformationViewModel(selectedCoin, cryptoApiService, mainWindowViewModel);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
            e.Handled = true;
        }
    }
}