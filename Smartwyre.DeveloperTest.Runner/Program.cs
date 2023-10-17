using System;
using Smartwyre.DeveloperTest.Services.RebateService;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var rebateService = new RebateService();
        bool continueCalculating = true;

        while (continueCalculating)
        {
            rebateService.ShowRecords();
            // Ask user for input
            Console.WriteLine("Enter Rebate Identifier:");
            string rebateIdentifier = Console.ReadLine();

            Console.WriteLine("Enter Product Identifier:");
            string productIdentifier = Console.ReadLine();

            Console.WriteLine("Enter Volume:");
            if (decimal.TryParse(Console.ReadLine(), out decimal volume))
            {
                // Create CalculateRebateRequest object
                var request = new CalculateRebateRequest
                {
                    RebateIdentifier = rebateIdentifier,
                    ProductIdentifier = productIdentifier,
                    Volume = volume
                };

                // Call Calculate method and display the result
                CalculateRebateResult result = rebateService.Calculate(request);
                Console.WriteLine($"Calculation Result: Success = {result.Success}");
            }
            else
            {
                Console.WriteLine("Invalid volume input. Please enter a valid decimal number.");
            }

            // Ask user if they want to continue calculating
            Console.WriteLine("Do you want to calculate again? (yes/no)");
            string continueInput = Console.ReadLine().ToLower();
            continueCalculating = continueInput == "yes";
        }

        Console.WriteLine("Calculation finished. Press any key to exit.");
        Console.ReadKey();
    }
}
