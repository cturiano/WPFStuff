using System.Windows;
using System.Windows.Controls;

namespace WpfBasics
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

        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Description.Text);
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            WeldCB.IsChecked = AssemblyCB.IsChecked = PlasmaCB.IsChecked = LaserCB.IsChecked = PurchaseCB.IsChecked = RollCB.IsChecked = LatheCB.IsChecked = DrillCB.IsChecked = FoldCB.IsChecked = SawCB.IsChecked = false;
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CB_OnChecked(object sender, RoutedEventArgs e)
        {
            LengthTB.Text += ((CheckBox)sender).Name;
        }
    }
}