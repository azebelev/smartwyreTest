using System;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore
{
    private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

    public ProductDataStore()
    {
        products.Add("product1", new Product { Id = 1, Identifier = "product1", Price = 100.00m, Uom = "Each", SupportedIncentives = SupportedIncentiveType.FixedRateRebate });
        products.Add("product2", new Product { Id = 2, Identifier = "product2", Price = 150.00m, Uom = "Some", SupportedIncentives = SupportedIncentiveType.AmountPerUom });
        products.Add("product3", new Product { Id = 2, Identifier = "product3", Price = 140.00m, Uom = "Some", SupportedIncentives = SupportedIncentiveType.FixedCashAmount });
    }
    public Product GetProduct(string productIdentifier)
    {
        if (products.TryGetValue(productIdentifier, out var product))
        {
            Console.WriteLine($"Product found: Id={product.Id}, Identifier={product.Identifier}, Price={product.Price}, Uom={product.Uom}");
            return product;
        }
        Console.WriteLine($"Product not found for Identifier: {productIdentifier}");
        return null;
    }

    internal IEnumerable<Product> GetAllProducts()
    {
        return products.Values;
    }
}
