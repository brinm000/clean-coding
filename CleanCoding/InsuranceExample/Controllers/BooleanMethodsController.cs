using Microsoft.AspNetCore.Mvc;

namespace InsuranceExample.Controllers
{
    public class BooleanMethosController : Controller
    {
        /// <summary>
        /// Show the Index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Show a page for the customer to fill in their name, birthdate and address details
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Validates customer's name, birthdate and address details,
        /// and calculates insurance premium based on address details.
        /// A number of stickers will bew printed after validation and calculation.
        /// </summary>
        /// <param name="name">NAme of customer</param>
        /// <param name="address">address of customer</param>
        /// <param name="residence">residence of customer</param>
        /// <param name="birthdate">birthdate of customer</param>
        /// <param name="certificate"> whether the customer has a certificate for a well-secured house</param>
        /// <returns>Webpage View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string? name, string? address, string? residence, string? birthdate, bool certificate)
        {
            string viewName = "Success";
            double premium = 0;
            if (FormComplete(name, address, residence, birthdate, certificate))
            {                
                if (ValidAge(birthdate))
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

        /// <summary>
        /// Checks if all parameters have valid values
        /// </summary>
        /// <param name="name">Nme of customer</param>
        /// <param name="address">address of customer</param>
        /// <param name="residence">residence of customer</param>
        /// <param name="birthdate">birthdate of customer</param>
        /// <param name="certificate"> whether the customer has a certificate for a well-secured house</param>
        /// <returns>True when all parameters have valid values</returns>
        protected bool FormComplete(string? name, string? address, string? residence, string? birthdate, bool certificate)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(address) &&
                        !string.IsNullOrWhiteSpace(residence) &&
                            !string.IsNullOrWhiteSpace(birthdate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        protected bool ValidAge(string? birthdate) 
        {
            //calculate age 
            var birthDay = DateTime.Parse(birthdate);
            int birthYear = birthDay.Year;
            var now = DateTime.Now;
            int age = now.Year - birthYear;
            if (now < birthDay.AddYears(age))
            {
                age--;
            }

            // check age
            return age >= 18.0;
        }
    }
}
