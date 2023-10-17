using System;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Services.RebateService;

public class RebateCalculator
{
    public SupportedIncentiveType SupportedIncentives { get; init; }
    public Func<bool> ValidationCallBack { get; init; }
    public Func<decimal> Calculate { get; init; }
    public Product Product { get; init; }

    public bool Validate()
    {
        if (!Product.SupportedIncentives.HasFlag((SupportedIncentives)))
        {
            return false;
        }
        return ValidationCallBack();
    }
}