using System.Windows;
using CssCompositionTool.Controls;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Setup.Configuration;
using Microsoft.VisualStudio.Text.Editor;

namespace CssCompositionTool.Dialogs
{
    /// <summary>
    /// Interaction logic for Reconnect.xaml
    /// </summary>
    public partial class Reconnect : DialogWindow
    {
        public Reconnect()
        {
            InitializeComponent();
            ConnectionText.Text = CssCompositionToolPackage.ConnectionOther;

        }

       

        private void ReconnectButton_OnClick(object sender, RoutedEventArgs e)
        {
            CssCompositionToolPackage.ConnectionOther = ConnectionText.Text;
          //  CssClassesToolControl.ReConnect();
        }

        private void SetDefault_OnClick(object sender, RoutedEventArgs e)
        {
            CssCompositionToolPackage.ConnectionOther =
                @"Server=(localdb)\mssqllocaldb;Database=CssScriptClasses.db;Trusted_Connection=True;";
          //  CssClassesToolControl.ReConnect();
        }
    }
}
