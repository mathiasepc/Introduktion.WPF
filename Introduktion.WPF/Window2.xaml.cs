using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Introduktion.WPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        //variabler
        private int scoreTap = 0;
        DispatcherTimer _timer;
        TimeSpan _time;

        public Window2()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //laver en funktion for min button
            Button? button = sender as Button;

            //hentet herfra https://stackoverflow.com/questions/16748371/how-to-make-a-wpf-countdown-timer
            //sætter min tid til 10
            _time = TimeSpan.FromSeconds(10);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerDisplay.Text = _time.ToString("c");
                //når tiden er gået
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    MessageBox.Show($"godt gået du klikkede {Tap.Text} gange");
                }
                //hver gang der er gået et sekund
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            //start tiden
            _timer.Start();

            //gemmer min knap
            button.Visibility = Visibility.Hidden;

            //min timer delay compensation
            Thread.Sleep(900);

            //den knap som tæller dine klik bliver synlig
            TapButton.Visibility = Visibility.Visible;
        }
        private void TapButton_Click(object sender, RoutedEventArgs e)
        {
            //laver en funktion for min button
            Button? button = sender as Button;

            //laver en funktion til min tælle metode sådan når Tapbutton bliver trykket på
            if (button != null && button.Name == "TapButton")
            {
                if (_time > TimeSpan.Zero)
                {
                    //laver en som tæller mine klik
                    scoreTap++;
                    Tap.Text = scoreTap.ToString();
                }       
            }
        }
    }
}
