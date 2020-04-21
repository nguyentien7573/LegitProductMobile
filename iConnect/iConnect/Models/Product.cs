using System;
using System.Collections.Generic;
using System.Text;

namespace iConnect.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string categoryID { get; set; }
        public decimal price { get; set; }
        public float discount { get; set; }
        public string description { get; set; }
        public List<ProductImgeDetail> productImgeDetail { get; set; }

    }
}
