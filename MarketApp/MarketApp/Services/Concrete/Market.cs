using MarketApp.Data.Enums;
using MarketApp.Data.Models;
using MarketApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services.Concrete
{
    public class Market : IMarketable
    {
        public List<Sale> Sales { get => Sales; set => throw new NotImplementedException(); }
        public List<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region Constructors
        public Market()
        {
            Sales = new List<Sale>();
            Products = new List<Product>();
        }
        public Market(List<Sale> sales, List<Product> products>)
        {
            Sales = sales;
            Products = products;
        }
        public Market(List<Sale> sales)
        {
            Sales = sales;
            Products = new List<Product>();
        }
        public Market(List<Product> products)
        {
            Sales = new List<Sale>();
            Products = products;
        }
        #endregion

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException("Product object cannot be null.");

            Products.Add(product);
        }

        public void AddSale(Sale sale)
        {
            if (sale == null) throw new ArgumentNullException("Sale object cannot be null.");

            Sales.Add(sale);
        }

        public void RefundEntireSale(int saleId)
        {
            Sale foundSale = (Sale)(from sale in Sales
                                where sale.ID == saleId
                                select sale);

            if (foundSale == null) throw new ArgumentException($"There is no corresponding sale object to the given sale ID: {saleId}");

            Sales.Remove(foundSale);
        }

        public void RefundProduct(int saleId, int saleitemId)
        {
            Sale foundSale = (Sale)(from sale in Sales
                                    where sale.ID == saleId
                                    select sale);
            if (foundSale == null) throw new ArgumentException($"There is no corresponding sale object to the given sale ID: {saleId}");

            SaleItem foundSaleItem = (SaleItem)
                (from saleitem in foundSale.SaleItems
                 where saleitem.ID == saleitemId
                 select saleitem);

            if (foundSaleItem == null) throw new ArgumentException($"There is no corresponding sale object to the given sale ID: {saleId}");

            foundSale.SaleItems.Remove(foundSaleItem);
        }

        public List<Product> SearchProductByCategory(Category category)
        {
            var filteredProducts = from product in Products
                                where product.ProductCategory == category
                                select product;

            if (filteredProducts == null)
                throw new ArgumentException($"There is no corresponding product object to the given product category: {category}");

            return filteredProducts.ToList();
        }

        public List<Product> SearchProductsByName(string productName)
        {
            var filteredProducts = from product in Products
                                   where product.ProductName == productName
                                   select product;

            if (filteredProducts == null)
                throw new ArgumentException($"There is no corresponding product object to the given product name: {productName}");

            return filteredProducts.ToList();
        }

        public List<Product> SearchProductsByValue(decimal startValue, decimal endValue)
        {
            throw new NotImplementedException();
        }

        public Sale SearchSaleByExactDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Sale SearchSaleByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sale> SearchSalesByDateInterval(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Sale> SearchSalesByPriceInterval(decimal startPrice, decimal endPrice)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId, string Name, int productValue, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
