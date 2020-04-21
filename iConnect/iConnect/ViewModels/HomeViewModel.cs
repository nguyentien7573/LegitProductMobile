using iConnect.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iConnect.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> NominatedProducts { get; set; }

        public Command LoadCategoryCommand { get; set; }
        public Command LoadProductCommand { get; set; }
        public Command LoadNominatedCommand { get; set; }

        public HomeViewModel()
        {
            Title = "Legit";

            Categories = new ObservableCollection<Category>();
            Products = new ObservableCollection<Product>();
            NominatedProducts = new ObservableCollection<Product>();

            LoadCategoryCommand = new Command(async () => await ExecuteLoadCategoryCommand());
            LoadProductCommand = new Command(async () => await ExecuteLoadProductCommand());
            LoadNominatedCommand = new Command(async () => await ExecuteLoadNominatedProductsCommand());
        }

        async Task ExecuteLoadCategoryCommand()
        {
            IsBusy = true;
            
            try
            {
                Categories.Clear();
                var items = await CategoryStore.GetItemsAsync(true);
              
                foreach (var item in items)
                {
                    Categories.Add(item);
                }
                _ = ExecuteLoadProductCommand();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadProductCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var items = await ProductStore.GetItemsAsync(true);
               
                foreach (var item in items)
                {
                    Products.Add(item);
                }
                _ = ExecuteLoadNominatedProductsCommand();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadNominatedProductsCommand()
        {
            IsBusy = true;

            try
            {
                NominatedProducts.Clear();
                var items = await ProductStore.GetItemsAsync(true);

                foreach (var item in items)
                {
                    NominatedProducts.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
