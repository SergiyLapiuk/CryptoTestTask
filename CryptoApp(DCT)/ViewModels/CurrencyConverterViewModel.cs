using CryptoTestTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoTestTask.ViewModels
{
    public class CurrencyConverterViewModel : DependencyObject
    {
        public ObservableCollection<Asset> Coins { get; set; }

        public static readonly DependencyProperty FromCoinProperty =
            DependencyProperty.Register("FromCoin", typeof(Asset), typeof(CurrencyConverterViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty ToCoinProperty =
            DependencyProperty.Register("ToCoin", typeof(Asset), typeof(CurrencyConverterViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(double), typeof(CurrencyConverterViewModel), new PropertyMetadata(0.0));

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(double), typeof(CurrencyConverterViewModel), new PropertyMetadata(0.0));

        public Asset FromCoin
        {
            get { return (Asset)GetValue(FromCoinProperty); }
            set { SetValue(FromCoinProperty, value); }
        }

        public Asset ToCoin
        {
            get { return (Asset)GetValue(ToCoinProperty); }
            set { SetValue(ToCoinProperty, value); }
        }

        public double Amount
        {
            get { return (double)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public double Result
        {
            get { return (double)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public CurrencyConverterViewModel(ObservableCollection<Asset> coins)
        {
            Coins = coins;
        }

        public void Convert()
        {
            if (FromCoin != null && ToCoin != null && Amount > 0)
            {
                Result = (Amount / FromCoin.PriceUsd.GetValueOrDefault()) * ToCoin.PriceUsd.GetValueOrDefault();
            }
            else
            {
                MessageBox.Show("Please ensure all fields are filled correctly.");
            }
        }
    }
}
