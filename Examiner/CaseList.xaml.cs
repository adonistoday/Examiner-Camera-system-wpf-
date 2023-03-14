using System;
using System.Collections.Generic;
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
    /// Interaction logic for CaseList.xaml
    /// </summary>
    public partial class CaseList : Page
    {
        public CaseList()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new StartPage();
        }
    }
}
