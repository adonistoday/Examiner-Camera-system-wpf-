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
    /// Interaction logic for MediaReviewPanel.xaml
    /// </summary>
    public partial class MediaReviewPanel : UserControl
    {
        public MediaReviewPanel()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MediaList.Visibility = Visibility.Hidden;
            // Create an instance of the SecondUserControl
            VideoPlayer secondUserControl = new VideoPlayer();

            // Set the Content property of the ContentControl to the SecondUserControl instance
            SecondUserControlHost.Content = secondUserControl;
        }
    }
}
