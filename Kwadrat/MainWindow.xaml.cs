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

namespace Kwadrat
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

        private void TxtEdge_TextChanged(object sender, TextChangedEventArgs e)
        {
            double edgeLength;
            if (double.TryParse(TxtEdge.Text, out edgeLength) && edgeLength >= 0)
            {
                TxtArea.Text = Math.Pow(edgeLength, 2.0).ToString();
                TxtCircuit.Text = (edgeLength * 4).ToString();
                LblMessage.Content = String.Empty;
            }
            else
            {
                LblMessage.Content = "Enter positive number";
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtEdge.Text = String.Empty;
            TxtArea.Text = String.Empty;
            TxtCircuit.Text = String.Empty;
            LblMessage.Content = "Enter edge length";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtEdge.Text, out var edge) && edge <=380)
            {
                Rectangle.Height = edge;
                Rectangle.Width = edge;
                SolidColorBrush colour = (SolidColorBrush) new BrushConverter().ConvertFromString(CmbColours.Text);
                Rectangle.Stroke = colour;
                Rectangle.Fill = colour;
                Rectangle.Opacity = (ChkbTranslucent.IsChecked.Value) ? 0.5 : 1;
            }
            else
            {
                LblMessage.Content = "No data or the edge is to big";
            }
        }

        private void RbtnHide_Checked(object sender, RoutedEventArgs e)
        {
            Rectangle.Visibility = Visibility.Hidden;
        }

        private void RbtnShow_Checked(object sender, RoutedEventArgs e)
        {
            Rectangle.Visibility = Visibility.Visible;
        }
    }
}
