using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace audiopleer_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            media.Source = new Uri("C:\\Users\\MASTER\\audio\\pharaoh-odnim-celym-mp3");
            media.Play();

            media.Volume = 0.7;
        }
        private void AudioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(audioSlider.Value));
        }
        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            audioSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var result = dialog.ShowDialog();

            if ( result == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                foreach ( string file in files )
                {
                    FileTxt.Text = file + "\n";
                }
            }
            ofd.Filter = "MP3 files (*.mp3)|*.mp3";

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            var a = new Uri(System.IO.Path.GetFullPath(@"..\..\..\5094_900.png"), UriKind.Relative);
            ImageBrush nolik = new ImageBrush(new BitmapImage(a));
           
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }    
}
