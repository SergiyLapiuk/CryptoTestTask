using OxyPlot;
using OxyPlot.Series;
using CryptoTestTask.Models;
using CryptoTestTask.Services; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OxyPlot.Axes;

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

        public CoinInformationViewModel(Asset coin, ICryptoApiService cryptoApiService)
        {
            SelectedCoin = coin;
            _cryptoApiService = cryptoApiService ?? throw new ArgumentNullException(nameof(cryptoApiService));
        }

    }
}
