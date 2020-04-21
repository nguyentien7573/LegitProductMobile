using System;
using System.Collections.Generic;
using System.Text;

namespace iConnect.Models
{
    public class ProductImgeDetail
    {
        public string img { get; set; }
        public string color { get; set; }

        public ProductImgeDetail(string img,string color)
        {
            this.img = img;
            this.color = color;
        }
    }
}
