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
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {
        string path;
        bool flag = false;
        public VideoPlayer()
        {
            InitializeComponent();
            string rootPath = @"D:\temp";
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            string today = DateTime.Now.ToString("MMddyy");
            int cntDir = 0;
            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i].Contains("CaseWindowsTest-" + today)) cntDir++;
            }
            path = System.IO.Path.Combine(rootPath, "CaseWindowsTest-" + today + "-" + cntDir.ToString());
            // 
            
            
        }
        private void PlayButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(flag==false)
            {
                Player.Source = new Uri(System.IO.Path.Combine(path, "recordedVideo.avi"));
                MessageBox.Show(Player.Source.ToString());
                Player.Play();
                flag = true;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/assets/images landscape/media review/button_stop.png", UriKind.Relative);
                bitmap.EndInit();
                PlayButton.Source = bitmap;
                // Start playing the video

            }
            else
            {
                Player.Pause();
                flag = false;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/assets/images landscape/media review/button_play.png", UriKind.Relative);
                bitmap.EndInit();
                PlayButton.Source = bitmap;
            }

        }
    }
}
