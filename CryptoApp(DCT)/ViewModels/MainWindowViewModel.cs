using CryptoTestTask.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Threading.Tasks;
using CryptoTestTask.Models;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using CryptoTestTask.Commands;

namespace CryptoTestTask.ViewModels
{
    public class MainWindowViewModel : DependencyObject, INotifyPropertyChanged
    {
        private readonly ICryptoApiService _cryptoApiService;

        public static readonly DependencyProperty CoinsProperty =
            DependencyProperty.Register("Coins", typeof(ObservableCollection<Asset>), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty FilteredCoinProperty =
            DependencyProperty.Register("FilteredCoin", typeof(ICollectionView), typeof(MainWindowViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedCoinProperty =
            DependencyProperty.Register("SelectedCoin", typeof(Asset), typeof(MainWindowViewModel), new PropertyMetadata(null, OnSelectedCoinChanged));

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(Page), typeof(MainWindowViewModel), new PropertyMetadata(null, OnCurrentPageChanged));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public Page CurrentPage
        {
            get { return (Page)GetValue(CurrentPageProperty); }
            set
            {
                SetValue(CurrentPageProperty, value);
                OnPropertyChanged(nameof(CurrentPage)); 
            }
        }

        public ICommand NavigateCommand { get; }
        public ICommand FindCommand { get; }
        public ICommand ConvertCommand { get; }
        public ICommand SettingsCommand { get; }

        public MainWindowViewModel(ICryptoApiService cryptoApiService)
        {
            _cryptoApiService = cryptoApiService;
            LoadCoins();

            CurrentPage = new MainPage(this);

            NavigateCommand = new RelayCommand(param => Navigate("MainPage"));
            FindCommand = new RelayCommand(param => Navigate("FindPage"));
            ConvertCommand = new RelayCommand(param => Navigate("ConverterPage"));
            SettingsCommand = new RelayCommand(param => Navigate("SettingsPage"));
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

        private static void OnCurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as MainWindowViewModel;
            viewModel?.OnPropertyChanged(nameof(CurrentPage));
        }

        private void OpenCoinInformationWindow(Asset coin)
        {
            CurrentPage = new CoinInformation(coin);
        }

        private void Navigate(string pageName)
        {
            switch (pageName)
            {
                case "MainPage":
                    CurrentPage = new MainPage(this);
                    break;
                case "ConverterPage":
                    CurrentPage = new CurrencyConverter(Coins);
                    break;
                case "FindPage":
                    var findViewModel = new FindCryptoCoinViewModel(this);
                    CurrentPage = new FindCryptoCoin { DataContext = findViewModel };
                    break;
                case "SettingsPage":
                    CurrentPage = new Settings();
                    break;
                default:
                    CurrentPage = new MainPage(this); // Default to main page
                    break;
            }
        }
    }
}
