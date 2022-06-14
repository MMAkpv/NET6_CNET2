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


        private async void btnParallel1_Click(object sender, RoutedEventArgs e)
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

            //Parallel.ForEach(files, file =>
            //{
            //    var result = FreqAnalysis.FreqAnalysisFromFile(file);

            //    string message = "";

            //    message += result.Source;
            //    message += Environment.NewLine;

            //    foreach (var word in result.GetTop10())
            //    {
            //        message += $"{word.Key}\t{word.Value}{Environment.NewLine}";
            //    }

            //    message += "\n";
            //    progress.Report(message);

            //});

            //asynchronně
            await Parallel.ForEachAsync(files, async (file, cancellationToken) =>
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

        private void btnNetFirst_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://ictpro.cz";

            var t1 = Task.Run(() => WebLoader.LoadUrl(url1));
            var t2 = Task.Run(() => WebLoader.LoadUrl(url2));
            var t3 = Task.Run(() => WebLoader.LoadUrl(url3));

            Task.WaitAny(t1,t2,t3);

            txbInfo.Text += "Doběhl první task";

            s.Stop();
            txbInfo.Text += ($"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi

        }

        private void btnNetAll_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://ictpro.cz";

            var t1 = Task.Run(() => WebLoader.LoadUrl(url1));
            var t2 = Task.Run(() => WebLoader.LoadUrl(url2));
            var t3 = Task.Run(() => WebLoader.LoadUrl(url3));

            Task.WaitAll(t1, t2, t3);

            txbInfo.Text += "Doběhly všechny tasks";

            s.Stop();
            txbInfo.Text += ($"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi
        }

        private async void btnNetFirstWhen_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            string url1 = "https://seznam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://ictpro.cz";

            var t1 = Task.Run(() => WebLoader.LoadUrl(url1));
            var t2 = Task.Run(() => WebLoader.LoadUrl(url2));
            var t3 = Task.Run(() => WebLoader.LoadUrl(url3));

            var firstDone = await Task.WhenAny(t1, t2, t3);
            txbInfo.Text +=  $"Doběhl první task, web length je {firstDone.Result}";

            s.Stop();
            txbInfo.Text += ($"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi
        }

        private async void btnNetAllWhen_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait; //pridam si cekaci kolecko misto mysi
            Stopwatch s = Stopwatch.StartNew();
            txbInfo.Text = "";

            string url1 = "https://sezcnam.cz";
            string url2 = "https://seznamzpravy.cz";
            string url3 = "https://ictpro.cz";

            var t1 = Task.Run(() => WebLoader.LoadUrl(url1));
            var t2 = Task.Run(() => WebLoader.LoadUrl(url2));
            var t3 = Task.Run(() => WebLoader.LoadUrl(url3));

            var results = await Task.WhenAll(t1, t2, t3);
            txbInfo.Text += $"Doběhly všechny tasky, web lengthy jsou {string.Join(", ", results)}";

            s.Stop();
            txbInfo.Text += ($"\nElapsed milliseconds:\t{s.ElapsedMilliseconds}");
            Mouse.OverrideCursor = null; //vratim se k normalni ikonce mysi
        }
    }
}
