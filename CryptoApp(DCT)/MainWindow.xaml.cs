using CryptoTestTask.Services;
using CryptoTestTask.ViewModels;
using System.Windows;

namespace CryptoTestTask
{
    public partial class MainWindow : Window
    {
        private readonly ICryptoApiService _cryptoApiService;

        public MainWindow()
        {
            InitializeComponent();

            _cryptoApiService = new CryptoApiService();
            DataContext = new MainWindowViewModel(_cryptoApiService);
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            var findViewModel = new FindCryptoCoinViewModel((MainWindowViewModel)DataContext);
            var findWindow = new FindCryptoCoin { DataContext = findViewModel };
            findWindow.Show();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            var converterWindow = new CurrencyConverter((DataContext as MainWindowViewModel).Coins);
            converterWindow.Show();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new Settings();
            settingsWindow.Show();
        }

    }
}
