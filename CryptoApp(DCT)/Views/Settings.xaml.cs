using CryptoTestTask.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CryptoTestTask
{
    public partial class Settings : Page
    {
        private readonly SettingsViewModel _viewModel;

        public Settings()
        {
            InitializeComponent();
            _viewModel = new SettingsViewModel();
        }

        private void SwitchThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var toggleButton = sender as ToggleButton;
            if (toggleButton != null)
            {
                if (toggleButton.IsChecked == true)
                {
                    _viewModel.SwitchTheme();
                    toggleButton.Content = "Light Theme";
                }
                else
                {
                    _viewModel.SwitchTheme();
                    toggleButton.Content = "Dark Theme";
                }
            }
        }


    }
}
