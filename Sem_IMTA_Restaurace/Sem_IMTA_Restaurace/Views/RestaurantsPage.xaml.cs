using Sem_IMTA_Restaurace.Models;
using Sem_IMTA_Restaurace.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem_IMTA_Restaurace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        MainPageViewModel viewModel;
        public RestaurantsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Restaurant item))
                return;

            await Navigation.PushAsync(new RestaurantDetail(new RestaurantDetailViewModel(item)));
        }
    }
}