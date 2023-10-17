namespace Smartwyre.DeveloperTest.Services.RebateService;

public interface IRebateService
{
    CalculateRebateResult Calculate(CalculateRebateRequest request);
}
