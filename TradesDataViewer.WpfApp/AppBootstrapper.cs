// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The trades data viewer app bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.WpfApp
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;

    using Microsoft.Practices.Prism.MefExtensions;
    using Microsoft.Practices.Prism.Modularity;

    /// <summary>The application bootstrapper.</summary>
    public class AppBootstrapper : MefBootstrapper
    {
        /// <summary>Creates the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog" /> used by Prism.</summary>
        /// <returns>The directory module catalog.</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = AppDomain.CurrentDomain.BaseDirectory };
        }

        /// <summary>The configure aggregate catalog.</summary>
        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new ApplicationCatalog());
        }

        /// <summary>The create shell.</summary>
        /// <returns>The <see cref="DependencyObject"/>.</returns>
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }

        /// <summary>The initialize shell.</summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();
            var application = Application.Current;
            application.MainWindow = (Shell)this.Shell;
            application.MainWindow.Show();
        }
    }
}