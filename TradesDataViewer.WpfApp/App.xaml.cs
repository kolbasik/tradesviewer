// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.WpfApp
{
    using System;
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>The on startup.</summary>
        /// <param name="e">The e.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Start();
        }

        /// <summary>The start.</summary>
        private static void Start()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            try
            {
                var bootstrapper = new AppBootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>The app domain_ unhandled exception.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                HandleException(exception);
            }
        }

        /// <summary>The handle exception.</summary>
        /// <param name="ex">The ex.</param>
        private static void HandleException(Exception ex)
        {
            Trace.Fail("Unhandled Exception", ex.ToString());
            Environment.Exit(1);
        }
    }
}