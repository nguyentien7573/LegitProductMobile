using iConnect.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iConnect.ViewModels.ProductVM
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public Product Item { get; set; }
        public ProductDetailViewModel(Product item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
