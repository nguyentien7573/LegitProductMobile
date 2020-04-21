using iConnect.ViewModels.ProductVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iConnect.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        ProductDetailViewModel product;
        public ProductDetail(ProductDetailViewModel product)
        {
            InitializeComponent();

            BindingContext = this.product = product;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Color_Tapped(object sender, EventArgs e)
        {

        }
    }
}