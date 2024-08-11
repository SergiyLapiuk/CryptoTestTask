using CryptoTestTask.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Threading.Tasks;
using CryptoTestTask.Models;
using System;

namespace CryptoTestTask.ViewModels
{
    public class MainWindowViewModel : DependencyObject
    {
        private readonly ICryptoApiService _cryptoApiService;

        public static readonly DependencyProperty CoinsProperty =
            DependencyProperty.Register("Coins", typeof(ObservableCollection<Asset>), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty FilteredCoinProperty =
            DependencyProperty.Register("FilteredCoin", typeof(ICollectionView), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedCoinProperty =
            DependencyProperty.Register("SelectedCoin", typeof(Asset), typeof(MainWindowViewModel), new PropertyMetadata(null, OnSelectedCoinChanged));

        public ObservableCollection<Asset> Coins
        {
            get { return (ObservableCollection<Asset>)GetValue(CoinsProperty); }
            set { SetValue(CoinsProperty, value); }
        }

        public ICollectionView FilteredCoin
        {
            get { return (ICollectionView)GetValue(FilteredCoinProperty); }
            set { SetValue(FilteredCoinProperty, value); }
        }

        public Asset SelectedCoin
        {
            get { return (Asset)GetValue(SelectedCoinProperty); }
            set { SetValue(SelectedCoinProperty, value); }
        }

        public MainWindowViewModel(ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;
            LoadCoins();
        }

        private async void LoadCoins()
        {
            try
            {
                var coins = await _cryptoApiService.GetCoinsAsync();
                Coins = new ObservableCollection<Asset>(coins);
                FilteredCoin = CollectionViewSource.GetDefaultView(Coins);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load coins: {ex.Message}");
            }
        }

        private static void OnSelectedCoinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as MainWindowViewModel;
            var selectedCoin = e.NewValue as Asset;

            if (selectedCoin != null)
            {
                viewModel?.OpenCoinInformationWindow(selectedCoin);
            }
        }

        private void OpenCoinInformationWindow(Asset coin)
        {
            var coinInformationWindow = new CoinInformation(coin);
            coinInformationWindow.Show();
        }
    }
}
