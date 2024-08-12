using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using CryptoTestTask.Models;
using CryptoTestTask.Commands;
using System.Windows.Input;

namespace CryptoTestTask.ViewModels
{
    public class FindCryptoCoinViewModel : DependencyObject
    {
        public static readonly DependencyProperty FilteredCoinProperty =
            DependencyProperty.Register("FilteredCoin", typeof(ICollectionView), typeof(FindCryptoCoinViewModel), new PropertyMetadata(null));

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(FindCryptoCoinViewModel), new PropertyMetadata("", FilterText_Changed));

        public ICollectionView FilteredCoin
        {
            get { return (ICollectionView)GetValue(FilteredCoinProperty); }
            set { SetValue(FilteredCoinProperty, value); }
        }

        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public ICommand NavigateToMainPageCommand { get; }

        private readonly MainWindowViewModel _mainViewModel;

        public FindCryptoCoinViewModel(MainWindowViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            FilteredCoin = CollectionViewSource.GetDefaultView(mainViewModel.Coins);
            FilteredCoin.Filter = FilterByCoin;

            NavigateToMainPageCommand = new RelayCommand(_ => NavigateToMainPage());
        }

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = d as FindCryptoCoinViewModel;
            if (viewModel != null)
            {
                viewModel.FilteredCoin.Filter = viewModel.FilterByCoin;
            }
        }

        private bool FilterByCoin(object obj)
        {
            var current = obj as Asset;
            if (!string.IsNullOrEmpty(FilterText) && current != null &&
                !current.Name.ToLower().Contains(FilterText.ToLower()) &&
                !current.Symbol.ToLower().Contains(FilterText.ToLower()))
            {
                return false;
            }
            return true;
        }

        private void NavigateToMainPage()
        {
            _mainViewModel.CurrentPage = new MainPage(_mainViewModel);
        }
    }
}