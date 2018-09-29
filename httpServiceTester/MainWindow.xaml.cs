using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace httpServiceTester
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

        static HttpClient client = new HttpClient();

        private void cleartxtbox(object sender, RoutedEventArgs e)
        {
            if ((responseTextBox.Text == "Response") & (responseTextBox.IsFocused)) responseTextBox.Text = "";
            if ((contentTextBox.Text == "Content") & (contentTextBox.IsFocused)) contentTextBox.Text = "";
            if ((addressTextBox.Text == "http address") & (addressTextBox.IsFocused)) addressTextBox.Text = "";
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            responseWebBrowser.NavigateToString(" ");

            try
            {
                WebRequest request = WebRequest.Create(addressTextBox.Text.ToString());
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseTextBox.Text = "";
                responseTextBox.Text = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception)
            {
                responseTextBox.Text = "Request returned an error";
            }

            responseWebBrowser.NavigateToString(responseTextBox.Text.ToString());
            



        }
    }
}
