using System.Windows;
using CryptoTestTask.Services;
using CryptoTestTask.ViewModels;

namespace CryptoTestTask
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            var cryptoApiService = new CryptoApiService();
            _viewModel = new MainWindowViewModel(cryptoApiService);
            DataContext = _viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;

            ViewModel_PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(MainWindowViewModel.CurrentPage)));

        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.CurrentPage))
            {
                if (_viewModel.CurrentPage != null)
                {
                    MainFrame.Navigate(_viewModel.CurrentPage);
                }
            }
        }
    }
}
