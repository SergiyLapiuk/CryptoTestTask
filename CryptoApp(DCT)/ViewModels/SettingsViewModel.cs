using System;
using System.Linq;
using System.Windows;

namespace CryptoTestTask.ViewModels
{
    public class SettingsViewModel
    {
        public void SwitchTheme()
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
    }
}
