using InsuranceCalculators.Models;
using System.Collections.Immutable;

namespace InsuranceCalculators
{
    public static class HomeInsuranceCalculator
    {
        private const int _minimumAge = 18;
        private const double _basePremium = 250.0;
        private const double _premiumIncreaseForRiskCity = 1.1;
        private const double _premiumDecreaseForCertificate = 0.75;

        private static readonly ImmutableArray<string> _citiesWithHigherRisk = ["amsterdam", "rotterdam", "utrecht"];
        private static readonly ImmutableArray<string> _certificateExceptionCities = ["amsterdam"];

        public static double CalculatePremiumForCustomer(Customer customer)
        {
            // basispremie
            var premium = _basePremium;
            string checkResidence = customer.Residence.ToLower();
            // premieverhogen ivm meer inbraken
            if (_citiesWithHigherRisk.Contains(checkResidence))
            {
                premium *= _premiumIncreaseForRiskCity;
            }
            // premieverlaging ivm certificaat
            if (customer.Certificate && !_certificateExceptionCities.Contains(checkResidence))
            {
                premium *= _premiumDecreaseForCertificate;
            }
            return premium;
        }
        
        public static bool ValidAge(Customer customer)
        {
            return customer.Age >= _minimumAge;
        }
    }
}
