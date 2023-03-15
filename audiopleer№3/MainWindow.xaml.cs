using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        private static List<string> list = new List<string>();
        private List<string> peremesh = new List<string>();    
        int pereklch = 0;
        int stop_play = 0;
        public MainWindow()
        {
            InitializeComponent();
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
                Regex regex = new Regex(@"\w*\.mp3");
                foreach (string item in files)
                {
                    if (regex.IsMatch(item))
                    {
                        Lsongs.Items.Add(regex.Match(item).Value);
                        list.Add(item);

                    }
                }

            }
            media.Source = new Uri(list[0]);
            media.Play();

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            pereklch--;
            media.Source = new Uri(list[pereklch]);
            media.Play();
        }


        private void Vpered_Click(object sender, RoutedEventArgs e)
        {
            pereklch++;
            media.Source = new Uri(list[pereklch]);
            media.Play();
        }

        private void Ugrat_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void Povtor_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            media.Play();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            peremesh = list;
            Random R = new Random();
            
            for (int i = 0; i < peremesh.Count; i++)
            {
                string tmp = peremesh[0];
                peremesh.RemoveAt(0);
                peremesh.Insert(R.Next(peremesh.Count), tmp);
            }
            media.Source = new Uri(peremesh[0]);
            media.Play();
        }

        private void STOP_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }
    }    
}
