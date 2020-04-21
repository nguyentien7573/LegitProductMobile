using iConnect.ViewModels;
using iConnect.ViewModels.ProductVM;
using iConnect.Views.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        HomeViewModel viewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCategoryCommand.Execute(true);
        }

        private void Category_Tapped(object sender, EventArgs e)
        {

        }

        private async void HotProduct_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Models.Product)layout.BindingContext;
            await Navigation.PushAsync(new ProductDetail(new ProductDetailViewModel(item)));
        }
    }
}