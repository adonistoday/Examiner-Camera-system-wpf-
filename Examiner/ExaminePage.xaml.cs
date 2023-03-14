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
using System.Windows.Shapes;

namespace Examiner
{
    /// <summary>
    /// Interaction logic for ExaminPage.xaml
    /// </summary>
    public partial class ExaminePage : Page
    {
        public ExaminePage(string path)
        {
            InitializeComponent();
            changeTabImage(0);
            
           // myGrid.Margin = new Thickness(20);
            Panel_Capture.Visibility = Visibility.Visible;
        }
        public void changeTabImage(int TabId)
        {
            Uri CaptureLock = new Uri(@"/assets/images landscape/general/navbar_capture0.jpg", UriKind.Relative);
            Uri CaptureNormal = new Uri(@"/assets/images landscape/general/navbar_capture1.jpg", UriKind.Relative);
            Uri CaptureClicked = new Uri(@"/assets/images landscape/general/navbar_capture2.jpg", UriKind.Relative);

            Uri MediaReviewLock = new Uri(@"/assets/images landscape/general/navbar_mediareview0.jpg", UriKind.Relative);
            Uri MediaReviewNormal = new Uri(@"/assets/images landscape/general/navbar_mediareview1.jpg", UriKind.Relative);
            Uri MediaReviewClicked = new Uri(@"/assets/images landscape/general/navbar_mediareview2.jpg", UriKind.Relative);

            Uri CaseDetailsNormal = new Uri(@"/assets/images landscape/general/navbar_casedetails1.jpg", UriKind.Relative);
            Uri CaseDetailsClicked = new Uri(@"/assets/images landscape/general/navbar_casedetails2.jpg", UriKind.Relative);

            Uri CaseListNormal = new Uri(@"/assets/images landscape/general/navbar_caselist1.jpg", UriKind.Relative);
            Uri CaseListClicked = new Uri(@"/assets/images landscape/general/navbar_caselist2.jpg", UriKind.Relative);

            CaptureBtn.Source = new BitmapImage(CaptureNormal);
            MediaReviewBtn.Source = new BitmapImage(MediaReviewNormal);
            CaseDetailBtn.Source = new BitmapImage(CaseDetailsNormal);
            CaseListBtn.Source = new BitmapImage(CaseListNormal);

            switch (TabId)
            {
                case 0:
                    CaptureBtn.Source = new BitmapImage(CaptureClicked);
                    break;
                case 1:
                    MediaReviewBtn.Source = new BitmapImage(MediaReviewClicked);
                    break;
                case 2:
                    CaseDetailBtn.Source = new BitmapImage(CaseDetailsClicked);
                    break;
                case 3:
                    CaseListBtn.Source = new BitmapImage(CaseListClicked);
                    break;
            }
        }

        public void HideAllPanel()
        {
            Panel_Capture.Visibility = Visibility.Hidden;
            Panel_MediaReview.Visibility = Visibility.Hidden;
            Panel_CaseDetail.Visibility = Visibility.Hidden;
        }

        private void CaptureBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideAllPanel();
            Panel_Capture.Visibility = Visibility.Visible;
            changeTabImage(0);
        }

        private void MediaReviewBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideAllPanel();
            Panel_MediaReview.Visibility = Visibility.Visible;
            changeTabImage(1);
        }

        private void CaseDetailBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideAllPanel();
            Panel_CaseDetail.Visibility = Visibility.Visible;
            changeTabImage(2);
        }

        private void CaseListBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new CaseList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new StartPage();
        }
    }
}
