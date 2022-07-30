using System;
using CssCompositionTool.Controls;

namespace CssCompositionTool
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CompositionWindowControl.
    /// </summary>
    public partial class CompositionWindowControl : UserControl
    {
        private  CssClassesToolControl _mainControl = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositionWindowControl"/> class.
        /// </summary>
        ///
        /// 
        public CompositionWindowControl()
        {
            this.InitializeComponent();
            MainPanel.Children.Add(MainControl);

        }

        

        public CssClassesToolControl MainControl
        {
            get
            {
                if (_mainControl == null)
                {
                        _mainControl = new CssClassesToolControl();
                }

                return (_mainControl);
            }
        }

        //public void SetupMainControl()
        //{
        //    MainControl.Margin = new Thickness(3);
        //    MainControl.Width = this.Width - 4;
        //    MainControl.Height = this.Height - 4;
        //    this.InvalidateVisual();
        //}

        

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "CompositionWindow");
        }

        //private void CompositionWindowControl_OnSizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    SetupMainControl();
        //}
    }
}