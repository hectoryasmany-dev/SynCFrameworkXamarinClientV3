using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SynCFrameworkXamarinClientV3.Views;
using SynCFrameworkXamarinClientV3.ViewModels;
using BIT.Xpo.Providers.OfflineDataSync;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace SynCFrameworkXamarinClientV3
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
