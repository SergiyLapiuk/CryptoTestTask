using CryptoTestTask.ViewModels;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CryptoTestTask
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void SwitchToWhiteTheme()
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative)
            });
        }

        private void SwitchToDarkTheme()
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative)
            });
        }

        private void SwitchThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.MergedDictionaries.Any(d => d.Source.ToString() == "Themes/LightTheme.xaml"))
            {
                var whiteTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.ToString() == "Themes/LightTheme.xaml");
                if (whiteTheme != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(whiteTheme);
                }
                SwitchToDarkTheme();
            }
            else
            {
                var darkTheme = Application.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.ToString() == "Themes/DarkTheme.xaml");
                if (darkTheme != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(darkTheme);
                }
                SwitchToWhiteTheme();
            }
        }
    }
}

