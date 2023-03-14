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
using Examiner;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using AForge.Controls;
using System.Threading;
using System.Windows.Threading;


namespace Examiner
{
    /// <summary>
    /// Interaction logic for CapturePanel.xaml
    /// </summary>
    public partial class CapturePanel : UserControl
    {
        VideoCaptureDevice LocalWebCam;
        public FilterInfoCollection LocalWebCamsCollection;
        private bool isRecording = false;
        private VideoFileWriter writer;
        private BitmapImage latestFrame;
        Action<BitmapImage> captureImage;
        private DispatcherTimer timer;
        int frameRate;
        DateTime currentTime;
        string path;
        public CapturePanel()
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
            MessageBox.Show(path);
            Loaded += CameraWindow_Loaded;
            Unloaded += CameraWindow_Unloaded;

        }
        void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                System.Drawing.Image img = (Bitmap)eventArgs.Frame.Clone();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                bi.Freeze();
                this.latestFrame = bi;
                Dispatcher.BeginInvoke(new ThreadStart(delegate
                {
                    videoImage.ImageSource = bi;
                }));
                writer.WriteVideoFrame((Bitmap)eventArgs.Frame.Clone());
            }
            catch (Exception ex)
            {
            }
        }
        private void CameraWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LocalWebCamsCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(LocalWebCamsCollection.Count>0)
            {
                LocalWebCam = new VideoCaptureDevice(LocalWebCamsCollection[1].MonikerString);
                LocalWebCam.VideoResolution = LocalWebCam.VideoCapabilities[0];
                LocalWebCam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
                frameRate = (int)LocalWebCam.VideoCapabilities[0].FrameRate;
                 MessageBox.Show(frameRate.ToString());
                LocalWebCam.Start();
            }
            else
            {
                MessageBox.Show("No camera!");
                return;
            }
            
        }

        private void CameraWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            LocalWebCam.Stop();
        }

        private void manualCapture_Click(object sender, RoutedEventArgs e)
        {
            if (captureImage != null)
            {
                captureImage(latestFrame);
            }
        }
        private Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (captureImage != null)
            {
                captureImage(latestFrame);
            }
            
            Bitmap bm = BitmapImageToBitmap(latestFrame);
            string filepath;
            string curtime = DateTime.Now.ToString();
            filepath= System.IO.Path.Combine(path, curtime+".jpg");
            bm.Save(filepath, ImageFormat.Jpeg);
            
        }
       

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!isRecording)
            {

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);

                // Add an event handler for the Tick event
                timer.Tick += Timer_Tick;

                // Start the timer
                timer.Start();
                currentTime = DateTime.Now;
               // TimeLabel.Content = DateTime.Now.ToString();
                // Initialize video file writer
                writer = new VideoFileWriter();
                writer.Open(System.IO.Path.Combine(path,currentTime.ToString()+".avi"), 640, 480,12, VideoCodec.MPEG4);

                // Update UI
                //  recordButton.Content = "Stop";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/assets/images landscape/capture/button_video2.png", UriKind.Relative);
                bitmap.EndInit();
                btn_video.Source = bitmap;
                isRecording = true;

            }
            else
            {
                // Stop video capture
                //   videoDevice.NewFrame -= OnNewFrame;
                //   videoDevice.SignalToStop();
                //   videoDevice.WaitForStop();

                // Close video file writer
                writer.Close();

                // Update UI
                //   recordButton.Content = "Record";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("/assets/images landscape/capture/button_video1.png", UriKind.Relative);
                bitmap.EndInit();
                btn_video.Source = bitmap;
                isRecording = false;
                
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate the time from now
            TimeSpan timeFromNow = DateTime.Now - currentTime;
            
            // Format the time as hours, minutes, and seconds
            string formattedTime = string.Format("{0:hh}: {0:mm}: {0:ss}", timeFromNow);

            // Update the label text
            TimeLabel.Content = formattedTime;
        }
    }
}
