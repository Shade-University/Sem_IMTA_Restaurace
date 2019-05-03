using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sem_IMTA_Restaurace.Views;
using Sem_IMTA_Restaurace.Services;

namespace Sem_IMTA_Restaurace
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<RestaurantDataStore>();
            MainPage = new NavigationPage(new RestaurantsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
