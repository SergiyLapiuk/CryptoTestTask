//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace CryptoTestTask.ViewModels
//{
//    public class SettingsViewModel : INotifyPropertyChanged
//    {
//        private bool isDarkTheme;

//        public bool IsDarkTheme
//        {
//            get { return isDarkTheme; }
//            set
//            {
//                if (isDarkTheme != value)
//                {
//                    isDarkTheme = value;
//                    OnPropertyChanged(nameof(IsDarkTheme));
//                    ApplyTheme();
//                }
//            }
//        }

//        //public SettingsViewModel()
//        //{
//        //    isDarkTheme = Properties.Settings.Default.CryptoTestTask;
//        //    ApplyTheme();
//        //}

//        //private void ApplyTheme()
//        //{
//        //    var app = Application.Current;
//        //    var uri = new Uri(isDarkTheme ? "Themes/DarkTheme.xaml" : "Themes/LightTheme.xaml", UriKind.Relative);

//        //    // Оновлюємо ресурсний словник додатку
//        //    app.Resources.MergedDictionaries.Clear();
//        //    app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });

//        //    // Оновлюємо всі відкриті вікна
//        //    foreach (Window window in app.Windows)
//        //    {
//        //        window.Resources.MergedDictionaries.Clear();
//        //        window.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
//        //    }

//        //    Properties.Settings.Default.CryptoTestTask = isDarkTheme;
//        //    Properties.Settings.Default.Save();
//        //}


//        public event PropertyChangedEventHandler PropertyChanged;

//        protected void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
//}
