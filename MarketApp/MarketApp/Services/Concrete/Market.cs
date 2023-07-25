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
            var filteredProducts = from product in Products
                                   where product.ProductValue >= startValue
                                   && product.ProductValue <= endValue
                                   select product;

            if (filteredProducts == null)
                throw new ArgumentException($"There is no corresponding product object to the given product value interval: [{startValue}, [{endValue}]");

            return filteredProducts.ToList();
        }

        public List<Sale> SearchSaleByExactDate(DateTime date)
        {
            var filteredSales = from sale in Sales
                                where
                                sale.Date.Year == date.Year &&
                                sale.Date.Month == date.Month &&
                                sale.Date.Day == date.Day

                                select sale;

            return filteredSales.ToList() ?? new List<Sale>();
        }

        public Sale SearchSaleByID(int id)
        {
            var foundSale = (Sale)(from sale in Sales
                            where sale.ID == id
                            select sale);

            if (foundSale == null)
                throw new ArgumentException($"There is no corresponding sale object to the given sale ID: {id}");

            return foundSale;
        }

        public List<Sale> SearchSalesByDateInterval(DateTime startDate, DateTime endDate)
        {
            var filteredSaled = from sale in Sales
                                where sale.Date >= startDate && sale.Date <= endDate
                                select sale;

            if (filteredSaled == null) throw new ArgumentException($"There is no corresponding sale object in the given date-time interval: [{startDate}, {endDate}]");

            return filteredSaled.ToList();
        }

        public List<Sale> SearchSalesByPriceInterval(decimal startPrice, decimal endPrice)
        {
            var filteredSales = from sale in Sales
                                where sale.FinalPrice >= startPrice && sale.FinalPrice <= endPrice
                                select sale;

            if (filteredSales == null) throw new ArgumentException($"There is no corresponding sale object in the given price interval: [{startPrice}, {endPrice}]");

            return filteredSales.ToList();
        }

        public void UpdateProduct(int productId, string Name, int productValue, Category category)
        {
            var foundProduct = (Product)(from product in Products
                                         where product.ID == productId
                                         select product);

            if (foundProduct == null) throw new ArgumentException($"There is no corresponding product object by the given product ID: {productId}");

            foundProduct.ProductName = Name;
            foundProduct.ProductValue = productValue;
            foundProduct.ProductCategory = category;
        }
    }
}
