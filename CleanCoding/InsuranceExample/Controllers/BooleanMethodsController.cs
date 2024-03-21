﻿using Microsoft.AspNetCore.Mvc;

namespace InsuranceExample.Controllers
{
    public class BooleanMethosController : Controller
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
        public IActionResult Create(string? name, string? address, string? residence, string? birthdate, bool certificate)
        {
            string viewName = "Success";
            double premium = 0;
            // alles moet zijn ingevuld
            if (FormComplete(name, address, residence, birthdate, certificate))
            {                
                if (ValidAge(birthdate))
                {
                    // basispremie
                    premium = 250.0;
                    string checkResidence = residence.ToLower();
                    // premieverhogen ivm meer inbraken
                    if (checkResidence == "amsterdam" ||
                        checkResidence == "rotterdam" ||
                            checkResidence == "utrecht")
                    {
                        premium = premium * 1.1;
                    }
                    // premieverlaging ivm certificaat
                    if (certificate && checkResidence != "amsterdam")
                    {
                        premium = 0.75 * premium;
                    }
                }
                else
                {
                    viewName = "TooYoung";
                }
            }
            else
            {
                viewName = "NotFilledIn";
            }
            if (viewName == "Success")
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
            return View(viewName);
        }

        private bool FormComplete(string? name, string? address, string? residence, string? birthdate, bool certificate)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(address) &&
                        !string.IsNullOrWhiteSpace(residence) &&
                            !string.IsNullOrWhiteSpace(birthdate);
        }

        private bool ValidAge(string? birthdate) 
        {
            // bereken leeftijd
            var birthDay = DateTime.Parse(birthdate);
            int birthYear = birthDay.Year;
            var now = DateTime.Now;
            int age = now.Year - birthYear;
            if (now < birthDay.AddYears(age))
            {
                age--;
            }

            // controleer leeftijd
            return age >= 18.0;
        }
    }
}