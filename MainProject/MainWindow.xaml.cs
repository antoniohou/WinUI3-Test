using Microsoft.UI.Xaml;
using System.IO;
using System.IO.Pipes;

namespace MainProject
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            using (NamedPipeClientStream client = new NamedPipeClientStream("testpipe"))
            {
                try
                {
                    client.Connect(5000);
                    StreamReader sr = new StreamReader(client);
                    StreamWriter sw = new StreamWriter(client);

                    string message = "Hello world!";
                    sw.WriteLine(message);
                    sw.Flush();
                    string response = sr.ReadLine();

                    myButton.Content = response;
                }
                catch { }
            }
        }
    }
}
