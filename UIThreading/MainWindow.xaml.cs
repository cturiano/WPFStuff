using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace UIThreading
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private async void MyButton_OnClick(object sender, RoutedEventArgs e)
        {
            Stream html = null;
            await Task.Run(async () =>
                           {
                               var hc = new HttpClient();
                               const string uri = "http://angelsix.com";
                               html = await hc.GetStreamAsync(uri);
                           });
            Browser.NavigateToStream(html);
        }

        #endregion
    }
}