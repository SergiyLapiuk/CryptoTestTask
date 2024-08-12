using CryptoTestTask.Commands;
using CryptoTestTask.Models;
using CryptoTestTask.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace CryptoTestTask.ViewModels
{
    public class CoinInformationViewModel : DependencyObject
    {
        public static readonly DependencyProperty SelectedCoinProperty =
            DependencyProperty.Register("SelectedCoin", typeof(Asset), typeof(CoinInformationViewModel));

        public Asset SelectedCoin
        {
            get { return (Asset)GetValue(SelectedCoinProperty); }
            set { SetValue(SelectedCoinProperty, value); }
        }

        private readonly ICryptoApiService _cryptoApiService;
        private readonly MainWindowViewModel _mainViewModel;

        public ICommand NavigateToMainPageCommand { get; }

        public CoinInformationViewModel(Asset coin, ICryptoApiService cryptoApiService, MainWindowViewModel mainViewModel)
        {
            SelectedCoin = coin;
            _cryptoApiService = cryptoApiService ?? throw new ArgumentNullException(nameof(cryptoApiService));
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));

            NavigateToMainPageCommand = new RelayCommand(_ => NavigateToMainPage());
        }

        private void NavigateToMainPage()
        {
            _mainViewModel.CurrentPage = new MainPage(_mainViewModel);
        }
    }
}
