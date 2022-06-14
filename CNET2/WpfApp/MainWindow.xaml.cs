using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            var files = Directory.EnumerateFiles(@"C:\Users\PC\Desktop\bigfiles", "*.txt");

            foreach ( var file in files)
            {
                var result = FreqAnalysis.FreqAnalysisFromFile(file);

                txbInfo.Text += result.Source;
                txbInfo.Text += Environment.NewLine;

                foreach (var word in result.GetTop10())
                {
                    txbInfo.Text += $"{word.Key}\t{word.Value}{Environment.NewLine}";
                }

                txbInfo.Text += "\n";
            }

            s.Stop();
            txbInfo.Text += $"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi

        }


        private void btnParallel1_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            var files = Directory.EnumerateFiles(@"C:\Users\PC\Desktop\bigfiles", "*.txt");

            //kvůli předáni hodnoty z vlákna do vlákna gui
            IProgress<string> progress = new Progress<string>(message =>
            {
                txbInfo.Text += message;
            });

            Parallel.ForEach(files, file =>
            {
                var result = FreqAnalysis.FreqAnalysisFromFile(file);

                string message = "";

                message += result.Source;
                message += Environment.NewLine;

                foreach (var word in result.GetTop10())
                {
                    message += $"{word.Key}\t{word.Value}{Environment.NewLine}";
                }

                message += "\n";
                progress.Report(message);

            });

            s.Stop();
            progress.Report($"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi

        }

        
    }
}
