using System;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore
{
    private readonly Dictionary<string, Rebate> rebates = new Dictionary<string, Rebate>();

    public RebateDataStore()
    {
        rebates.Add("rebate1", new Rebate { Identifier = "rebate1", Incentive = IncentiveType.FixedRateRebate, Amount = 10.00m, Percentage = 0.05m });
        rebates.Add("rebate2", new Rebate { Identifier = "rebate2", Incentive = IncentiveType.AmountPerUom, Amount = 2.00m, Percentage = 0.2m });
        rebates.Add("rebate3", new Rebate { Identifier = "rebate3", Incentive = IncentiveType.FixedCashAmount, Amount = 22.00m, Percentage = 0.1m });
    }

    public Rebate GetRebate(string rebateIdentifier)
    {
        if (rebates.TryGetValue(rebateIdentifier, out var rebate))
        {
            Console.WriteLine($"Rebate found: Identifier={rebate.Identifier}, Incentive={rebate.Incentive}, Amount={rebate.Amount}, Percentage={rebate.Percentage}");
            return rebate;
        }
        Console.WriteLine($"Rebate not found for Identifier: {rebateIdentifier}");
        return null;
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        if (rebates.ContainsKey(account.Identifier))
        {
            rebates[account.Identifier].Amount = rebateAmount;
            Console.WriteLine($"Rebate amount of {account.Identifier} updated, new Amount = {rebates[account.Identifier].Amount}");
        }
    }

    internal IEnumerable<Rebate> GetAllRebates()
    {
        return rebates.Values;
    }
}
