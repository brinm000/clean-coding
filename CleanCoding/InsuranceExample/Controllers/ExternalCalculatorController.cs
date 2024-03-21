using InsuranceCalculators;
using InsuranceCalculators.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExample.Controllers;

public class ExternalCalculatorController : Controller

{
    private const int _numberOfStickersToPrint = 5;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (!ValidAge(customer))
        {
            return View("TooYoung");
        }

        CalculatePremium(customer);
        PrintStickers(customer);

        return View("Success");
    }

    private static void PrintStickers(Customer customer)
    {
        for (int i = 0; i < _numberOfStickersToPrint; i++)
        {
            Console.WriteLine(customer.Name);
            Console.WriteLine($"{customer.Address} {customer.Residence}");
            Console.WriteLine(customer.BirthDate);
            Console.WriteLine($"Premium: {customer.Premium}");
            Console.WriteLine();
        }
    }

    private static void CalculatePremium(Customer customer)
    {
        customer.Premium = HomeInsuranceCalculator.CalculatePremiumForCustomer(customer);
    }

    private bool ValidAge(Customer customer)
    {
        return HomeInsuranceCalculator.ValidAge(customer);
    }
}
