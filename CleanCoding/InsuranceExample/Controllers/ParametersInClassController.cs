using InsuranceExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExample.Controllers
{
    public class ParametersInClassController : Controller
    {
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
            for (int i = 0; i < 5; i++)
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
            customer.Premium = 250.0;
            string checkResidence = customer.Residence.ToLower();
            // premieverhogen ivm meer inbraken
            if (checkResidence == "amsterdam" ||
                checkResidence == "rotterdam" ||
                    checkResidence == "utrecht")
            {
                customer.Premium *= 1.1;
            }
            // premieverlaging ivm certificaat
            if (customer.Certificate && checkResidence != "amsterdam")
            {
                customer.Premium *= 0.75;
            }
        }

        private bool ValidAge(Customer customer)
        {
            return customer.Age >= 18;           
        }
    }
}
