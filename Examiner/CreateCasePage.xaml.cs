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
    /// Interaction logic for CreateCasePage.xaml
    /// </summary>
    public partial class CreateCasePage : Page
    {
        string path;
        public CreateCasePage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new StartPage();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            //string path1 = @"D:\temp\";

            //string path2 = System.IO.Path.Combine(path1, "temp1");

            //// Create directory temp1 if it doesn't exist
            //Directory.CreateDirectory(path2);
            string rootPath = @"D:\temp";
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            string today = DateTime.Now.ToString("MMddyy");
            int cntDir=0;
            for(int i=0;i<dirs.Length;i++)
            {
                if (dirs[i].Contains("CaseWindowsTest-" + today)) cntDir++;
            }
            cntDir++;
            path = System.IO.Path.Combine(rootPath, "CaseWindowsTest-" + today + "-"+cntDir.ToString());
            Directory.CreateDirectory(path);
            parentWindow.Content = new ExaminePage(path);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
