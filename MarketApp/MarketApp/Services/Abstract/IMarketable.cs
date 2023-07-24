using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketApp.Data.Enums;
using MarketApp.Data.Models;

namespace MarketApp.Services.Abstract
{
    public interface IMarketable
    {
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; set; }
        public void AddSale(Sale sale);
        public void RefundProduct(Sale sale, Product product);
        public void RefundEntireSale(Sale sale);
        public List<Sale> SearchSalesByDateInterval(DateTime startDate, DateTime endDate);
        public Sale SearchSaleByExactDate(DateTime date);
        public List<Sale> SearchSalesByPriceInterval(decimal startPrice, decimal endPrice);
        public Sale SearchSaleByID(int id);
        
        public void AddProduct(Product product);
        public void UpdateProduct(int productId, string Name, int productValue, Category category);
        public List<Product> SearchProductByCategory(Category category);
        public List<Product> SearchProductsByValue(decimal startValue, decimal endValue);
        public List<Product> SearchProductsByName(string productName);
    }
}
