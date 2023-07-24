using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarketApp.Data.Enums;

namespace MarketApp.Data.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal ProductValue { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductCount { get; set; }
        public int ID { get; set; }
    }
}
