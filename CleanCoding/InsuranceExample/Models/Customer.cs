namespace InsuranceExample.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Residence { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public bool Certificate { get; set; }

        public double Premium { get; set; } = 0.0;

        public int Age 
        { 
            get 
            {
                int birthYear = BirthDate.Year;
                var now = DateTime.Now;
                int age = now.Year - birthYear;
                if (now < BirthDate.AddYears(age))
                {
                    age--;
                }

                return age;
            } 
        }
   }
}
