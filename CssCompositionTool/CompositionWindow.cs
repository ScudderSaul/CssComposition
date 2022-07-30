using System;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualStudio.Shell;

namespace CssCompositionTool
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    /// [Guid("b4810978-699b-4322-a4a2-95a75fd7a76e")]
    [Guid("1f6a698d-c806-4be6-b184-dca8e3aac5ab")]
    public class CompositionWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompositionWindow"/> class.
        /// </summary>
        public CompositionWindow() : base(null)
        {
            this.Caption = "CompositionWindow";

            

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new CompositionWindowControl();
        }


    }
}
