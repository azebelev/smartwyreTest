using Smartwyre.DeveloperTest.Services.RebateService;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public void Test1()
    {
        var rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "rebate1",
            ProductIdentifier = "product2",
            Volume = 10
        };
        var result = rebateService.Calculate(request);

        Assert.False(result.Success);
    }
    public void Test2()
    {
        var rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "rebate1",
            ProductIdentifier = "product1",
            Volume = 10
        };
        var result = rebateService.Calculate(request);

        Assert.Equal(50.00m,result.Value);
    }
    public void Test3()
    {
        var rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "notExistsRebate",
            ProductIdentifier = "product2",
            Volume = 10
        };
        var result = rebateService.Calculate(request);

        Assert.False(result.Success);
    }
    public void Test4()
    {
        var rebateService = new RebateService();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "rebate2",
            ProductIdentifier = "product2",
            Volume = 100
        };
        var result = rebateService.Calculate(request);

        Assert.Equal(100.00m,result.Value);
    }
}
