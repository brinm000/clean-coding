using Microsoft.AspNetCore.Mvc;

namespace InsuranceExample.Controllers;

public class RawController : Controller
{
    // Toont de index pagina voor het initiëren van klanten
    public IActionResult Index()
    {
        return View();
    }

    /// Toont een pagina om de gevevens van een klant in te voeren
    public IActionResult Create()
    {
        return View();
    }

    // Verwerkt de gegevens van een klant
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string? name, string? address, string? residence, string? birthdate, bool certificate)
    {
        CreateCustomer(name, address, residence, birthdate, certificate);
        return View();
    }

    // Maakt de klant aan
    private string CreateCustomer(string? name, string? address, string? residence, string? birthdate, bool certificate)
    {
        string createResult = "Success";
        double premium = 0;
        if (!string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrWhiteSpace(address) &&
                    !string.IsNullOrWhiteSpace(residence) &&
                        !string.IsNullOrWhiteSpace(birthdate))
        {
            var birthDay = DateTime.Parse(birthdate);
            int birthYear = birthDay.Year;
            var now = DateTime.Now;
            int age = now.Year - birthYear;
            if (now < birthDay.AddYears(age))
            {
                age--;
            }
            if (age >= 18)
            {
                premium = 250.0;
                string checkResidence = residence.ToLower();
                if (checkResidence == "amsterdam" ||
                    checkResidence == "rotterdam" ||
                        checkResidence == "utrecht")
                {
                    premium = premium * 1.1;
                }
                if (certificate && checkResidence != "amsterdam")
                {
                    premium = 0.75 * premium;
                }
            }
            else
            {
                createResult = "TooYoung";
            }
        }
        else
        {
            createResult = "NotFilledIn";
        }
        if (createResult == "Success")
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(name);
                Console.WriteLine($"{address} {residence}");
                Console.WriteLine(birthdate);
                Console.WriteLine($"Premium: {premium}");
                Console.WriteLine();
            }
        }
        return createResult;
    }
}
