using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace NetStatus
{
	public partial class App : Application
	{
		public App ()
		{
            // The root page of your application
            MainPage = CrossConnectivity.Current.IsConnected ? (Page)new NetworkViewPage() : new NoNetworkPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
		}

        // switch pages dynamically as network is enabled or disabled
        void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Type currentPage = this.MainPage.GetType();

            if (e.IsConnected && currentPage != typeof(NetworkViewPage))
            {
                this.MainPage = new NetworkViewPage();
            }
            else if (!e.IsConnected && currentPage != typeof(NoNetworkPage))
            {
                this.MainPage = new NoNetworkPage();
            }
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
