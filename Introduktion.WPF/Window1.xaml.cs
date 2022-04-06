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

namespace Introduktion.WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void CreateViewImageDynamically(object sender, RoutedEventArgs e)
        {
            //create image og propperties
            Image dynamicImage = new();
            dynamicImage.Width = 200;
            dynamicImage.Height = 150;

            //Create a bitmapsource
            BitmapImage bitmap = new();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"H:\\Firework.Test.jpg");
            bitmap.EndInit();

            //set Image.Source
            dynamicImage.Source = bitmap;

            //tilføj til grid
            Root.Children.Add(dynamicImage);

            //placering for billede
            Grid.SetColumn(dynamicImage, 4);
            Grid.SetRow(dynamicImage, 3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //laver en tryparse sådan så den kan omskrive fra text til tal.
            bool succes = int.TryParse(matematikSpørgsmålText.Text, out int number);
            if (succes)
            {
                if (number == 4)
                {
                    //hvis du har taster rigtigt kommer dette billede frem
                    CreateViewImageDynamically(sender, e);
                    MessageBox.Show($"Rigtig flot!");
                }
                else
                {
                    //hvis du taster forkert
                    MessageBox.Show($"Du er lort. Prøv igen.");
                    return;
                }
            }

            Window2 p = new();

            p.Show();

            this.Close();
            
        }
    }
}
