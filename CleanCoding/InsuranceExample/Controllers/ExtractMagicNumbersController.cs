using InsuranceExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace InsuranceExample.Controllers;

public class ExtractMagicNumbersController : Controller

{
    private const int _numberOfStickersToPrint = 5;
    private const int _minimumAge = 18;
    private const double _basePremium = 250.0;
    private const double _premiumIncreaseForRiskCity = 1.1;
    private const double _premiumDecreaseForCertificate = 0.75;

    private static readonly ImmutableArray<string> _citiesWithHigherRisk = ["amsterdam", "rotterdam", "utrecht"];
    private static readonly ImmutableArray<string> _certificateExceptionCities = ["amsterdam"];

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
        // basispremie
        customer.Premium = _basePremium;
        string checkResidence = customer.Residence.ToLower();
        // premieverhogen ivm meer inbraken
        if (_citiesWithHigherRisk.Contains(checkResidence))
        {
            customer.Premium *= _premiumIncreaseForRiskCity;
        }
        // premieverlaging ivm certificaat
        if (customer.Certificate && !_certificateExceptionCities.Contains(checkResidence))
        {
            customer.Premium *= _premiumDecreaseForCertificate;
        }
    }

    private bool ValidAge(Customer customer)
    {
        return customer.Age >= _minimumAge;
    }
}
