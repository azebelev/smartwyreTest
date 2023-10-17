using System;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Services.RebateService;

public class RebateCalculatorBuilder
{
    public readonly RebateCalculator rebateCalculator;

    public RebateCalculatorBuilder(Rebate rebate, Product product, CalculateRebateRequest request)
    {
        switch (rebate.Incentive)
        {
            case IncentiveType.FixedCashAmount:
                rebateCalculator = new RebateCalculator
                {
                    SupportedIncentives = SupportedIncentiveType.FixedCashAmount,
                    ValidationCallBack = () => rebate.Amount != 0,
                    Calculate = () => rebate.Amount,
                    Product = product
                };
                break;
            case IncentiveType.FixedRateRebate:
                rebateCalculator = new RebateCalculator
                {
                    SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
                    ValidationCallBack = () => rebate.Percentage != 0 && product.Price != 0 && request.Volume != 0,
                    Calculate = () => product.Price * rebate.Percentage * request.Volume,
                    Product = product
                };
                break;
            case IncentiveType.AmountPerUom:
                rebateCalculator = new RebateCalculator
                {
                    SupportedIncentives = SupportedIncentiveType.AmountPerUom,
                    ValidationCallBack = () => rebate.Amount != 0 && request.Volume != 0,
                    Calculate = () => rebate.Amount * request.Volume,
                    Product = product
                };
                break;
            default: throw new Exception("Incentive type not found.");
        }
    }

}