using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace UiDesktopAppDemo.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "Eaton Plant";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Home1",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Data",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        //[ObservableProperty]
        //private ObservableCollection<MenuItem> _trayMenuItems = new()
        //{
        //    new MenuItem { Header = "Home", Tag = "tray_home" }
        //};
        

        //[ObservableProperty]
        //private ObservableCollection<string> _breadCrums = new()
        //{
        //    "Test1","Test2"
        //};
    }
}
