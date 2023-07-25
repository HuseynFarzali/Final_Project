using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Data.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public int FinalPrice { get; set; }

        public List<SaleItem> SaleItems = new List<SaleItem>();
        public DateTime Date { get; set; }
    }
}
