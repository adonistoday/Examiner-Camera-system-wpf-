using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examiner
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new CreateCasePage();
            string path1 = @"D:\temp";
            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new CaseList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
