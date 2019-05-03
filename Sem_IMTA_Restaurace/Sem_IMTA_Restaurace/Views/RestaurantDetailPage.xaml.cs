using Sem_IMTA_Restaurace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem_IMTA_Restaurace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetail : ContentPage
    {
        public RestaurantDetail(RestaurantDetailViewModel model)
        {
            InitializeComponent();
        }
    }
}