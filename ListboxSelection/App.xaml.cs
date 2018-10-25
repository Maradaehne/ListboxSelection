using System;
using System.Windows;
using ListboxSelection.Views;
using Prism.Ioc;
using Prism.Unity;

namespace ListboxSelection
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    internal partial class App:  PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
containerRegistry.Register<MainView>();        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
    }
}
