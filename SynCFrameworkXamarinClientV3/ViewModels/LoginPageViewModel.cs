using System;
using BIT.Xpo.Providers.OfflineDataSync;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SynCFrameworkXamarinClientV3.Infrastructure;
using SynCFrameworkXamarinClientV3.Views;
using Xamarin.Forms;

namespace SynCFrameworkXamarinClientV3.ViewModels
{
    public class LoginPageViewModel : AppMapViewModelBase
    {
        string password;
        public Command SyncCommand { get; private set; }
        public Command LogInCommand { get; private set; }
        string cnx = SyncDataStoreAsynchronous.GetConnectionString(XpoHelper.GetConnectionString("Data"), XpoHelper.GetConnectionString("Delta"), "Mobile", "", false);
        string conexion2 = "XpoProvider=SyncDataStoreAsynchronous;DataConnectionString='XpoProvider=SQLite;Data Source=DataA.db';DeltaConnectionString='XpoProvider=SQLite;Data Source=DeltaA.db';EnableDeltaTracking='True';ExcludedEntities='';Identity=A";
        public LoginPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Syncframework Demo";
            LogInCommand = new Command(() => ExecuteLogInCommand(), () => Login?.Length > 0);
            SyncCommand = new Command(() => ExecuteSyncCommand(), () => !this.IsBusy);

           XpoHelper.InitXpoSync(conexion2, "https://aff109f045bf.ngrok.io");
        }



        
        public string Login
        {
            get { return login; }
            set { SetProperty(ref login, value); LogInCommand.ChangeCanExecute(); }
        }
        string login;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }



        void ExecuteLogInCommand()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }
                IsBusy = true;

                // XpoHelper.InitXpo(WebApiDataStoreClient.GetConnectionString("https://10.0.2.2:5001/xpo/"), Login, Password);
                XpoHelper.InitXpo(cnx, Login, Password);
                IsBusy = false;
                //if (Device.RuntimePlatform == Device.iOS)
                //    Application.Current.MainPage = new ItemsListView();
                //else
                //    Application.Current.MainPage = new NavigationPage(new ItemsListView());
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Login failed", ex.Message, "Try again");
                IsBusy = false;
            }
        }
        void ExecuteSyncCommand()
        {
            try
            {
                if (IsBusy)
                {
                    return;
                }
                IsBusy = true;


                //TODO remove hard code identity

                XpoHelper.Sync();
                IsBusy = false;

            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Login failed", ex.Message, "Try again");
                IsBusy = false;
            }
        }
    }
}
