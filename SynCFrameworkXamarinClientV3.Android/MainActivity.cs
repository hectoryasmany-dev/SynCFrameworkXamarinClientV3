using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using BIT.Xpo.Providers.OfflineDataSync;
using Prism;
using Prism.Ioc;

namespace SynCFrameworkXamarinClientV3.Droid
{
    [Activity(Label = "SynCFrameworkXamarinClientV3", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            var test = typeof(SyncDataStoreAsynchronous);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
        
    }
   

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

