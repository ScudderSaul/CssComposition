using System;
using System.Runtime.InteropServices;
using System.Threading;
using CssCompositionTool.Model;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using Task = System.Threading.Tasks.Task;

namespace CssCompositionTool
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// 
    /// from CssCompositionTool.622820af-cde7-4775-8caa-d0af02dab678
    /// CssCompositionTool.4c641290-13b4-4ab9-a53c-6ec9bced2398
    /// 
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(CssCompositionToolPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(CompositionWindow))]
    public sealed class CssCompositionToolPackage : AsyncPackage
    {
        /// <summary>
        /// CssCompositionToolPackage GUID string.
        /// </summary>
        //  public const string PackageGuidString = "d2a1fed1-5eb9-4143-86e3-4b7561e4b7ae";
        public const string PackageGuidString = "ced45a17-246f-45d1-9b16-9beca68f535a";

        public static string ConnectionOther = string.Empty;

        #region Package Members

        public static CssCompositionToolPackage PackageInstance = null;

        public void GetSqlConnection()
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "CssScriptClassesExt";
            const string keyName = userRoot + @"\Software\_Zen_Soft\" + subkey;

            // Your default value is returned if the name/value pair
            // does not exist.
            ConnectionOther = (string)Registry.GetValue(keyName,
                "SqlConnection",
                "Empty");


            if (ConnectionOther == "Empty")
            {
                ConnectionOther =
                    @"Server=(localdb)\mssqllocaldb;Database=CssScriptClasses.db;Trusted_Connection=True;";
            }

            if (string.IsNullOrEmpty(ConnectionOther))
            {
                ConnectionOther = @"Server=(localdb)\mssqllocaldb;Database=CssScriptClasses.db;Trusted_Connection=True;";
            }

            
        }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            GetSqlConnection();
            PackageInstance = this;
            await ToolMenuCommand.InitializeAsync(this);

            await CompositionWindowCommand.InitializeAsync(this);
        }

        #endregion
    }
}
