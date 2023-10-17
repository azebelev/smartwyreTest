using System;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Services.RebateService;

public class RebateService : IRebateService
{
    private readonly RebateDataStore rebateDataStore = new RebateDataStore();
    private readonly ProductDataStore productDataStore = new ProductDataStore();

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {

        Rebate rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        if (rebate == null || product == null)
        {
            Console.WriteLine("Some of requested entities not exist");
            return result;
        }

        var rebateCalculatorBuilder = new RebateCalculatorBuilder(rebate, product, request);
        var rebateCalculator = rebateCalculatorBuilder.rebateCalculator;

        if (!rebateCalculator.Validate())
        {
            Console.WriteLine("not enough data for calculating");
            return result;
        }
        else
        {
            result.Value = rebateCalculator.Calculate();
            rebateDataStore.StoreCalculationResult(rebate, result.Value);
            result.Success = true;
        }

        return result;
    }

    public void ShowRecords()
    {
        // Display Rebates
        Console.WriteLine("Rebates:");
        foreach (var rebate in rebateDataStore.GetAllRebates())
        {
            Console.WriteLine($"Identifier={rebate.Identifier}, Incentive={rebate.Incentive}, Amount={rebate.Amount}, Percentage={rebate.Percentage}");
        }

        // Display Products
        Console.WriteLine("Products:");
        foreach (var product in productDataStore.GetAllProducts())
        {
            Console.WriteLine($"Id={product.Id}, Identifier={product.Identifier}, Price={product.Price}, Uom={product.Uom}, SupportedIncentives={product.SupportedIncentives}");
        }
    }
}
