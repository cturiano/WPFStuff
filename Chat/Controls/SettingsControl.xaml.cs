using System.Windows.Controls;

namespace Chat.Controls
{
    /// <inheritdoc cref="UserControl" />
    /// <summary>
    ///     Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl
    {
        #region Constructors

        public SettingsControl()
        {
            InitializeComponent();
            DataContext = Core.IOC.IoC.SettingsViewModel;
        }

        #endregion
    }
}