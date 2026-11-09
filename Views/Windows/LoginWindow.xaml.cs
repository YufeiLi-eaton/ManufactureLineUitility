using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using UiDesktopAppDemo.ViewModels.Windows;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls;

namespace UiDesktopAppDemo.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : FluentWindow
    {
        public bool Show = true;
        private readonly ISnackbarService _snackbarService;
        private const int DWMWA_BORDER_COLOR = 34;
        private const uint DWMWA_COLOR_NONE = 0xFFFFFFFE;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int dwAttribute,
            ref uint pvAttribute,
            int cbAttribute);
        public LoginWindow()
        {
            Show = true;
            InitializeComponent();
            _snackbarService = new SnackbarService();
            _snackbarService.SetSnackbarPresenter(LoginSnackBar);
            SourceInitialized += LoginWindow_SourceInitialized;
            DataContext = this;

        }

        private RelayCommand loginCommand;
        public ICommand LoginCommand => loginCommand ??= new RelayCommand(Login);

        private void Login()
        {
            _snackbarService.Show("登录失败","用户名或密码错误",ControlAppearance.Danger,new SymbolIcon(SymbolRegular.ErrorCircle24),TimeSpan.FromSeconds(10));

        }

        private void LoginWindow_SourceInitialized(
           object? sender,
           EventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            RemoveDwmBorder(hwnd);
            ConfigureExistingWindowChrome();
        }

        private static void RemoveDwmBorder(IntPtr hwnd)
        {
            uint borderColor = DWMWA_COLOR_NONE;

            int result = DwmSetWindowAttribute(
                hwnd,
                DWMWA_BORDER_COLOR,
                ref borderColor,
                sizeof(uint));

            Debug.WriteLine($"DWM border result: 0x{result:X8}");
        }

        private void ConfigureExistingWindowChrome()
        {
            WindowChrome? chrome = WindowChrome.GetWindowChrome(this);

            if (chrome is null)
            {
                Debug.WriteLine("FluentWindow 当前没有 WindowChrome。");
                return;
            }

            chrome.GlassFrameThickness = new Thickness(0);
            chrome.ResizeBorderThickness = new Thickness(0);
            chrome.UseAeroCaptionButtons = false;
        }

    }
}
