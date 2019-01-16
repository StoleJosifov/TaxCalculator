using System;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateTax();
        }

        static void CalculateTax()
        {
            Console.WriteLine("Please input your gross salary. \n");
            var grossSalary = Console.ReadLine();
            try
            {
                var grossSalaryValue = Convert.ToDouble(grossSalary);
                var netSalary = GetNetSalary(grossSalaryValue);
                Console.WriteLine("\nYour net salary is {0} IDR", netSalary);
            }
            catch
            {
                Console.WriteLine("\nYour input must be a real positive number, please try again! \n");
                CalculateTax();
            }

            Console.WriteLine("\nPress C to calculate again or any other key to exit. \n");
            string result = Console.ReadLine();
            if (result.ToLower() == "c")
            {
                Console.Write("\n");
                CalculateTax();
            }
        }

        static double GetNetSalary(double grossSalary)
        {
            double netSalary = grossSalary;
            double noTaxationAmount = 1000;
            double socialContributionsLimitAmount = 3000;
            double incomeTaxAmount = 0;
            double socialContributionsAmount = 0;

            if (grossSalary > noTaxationAmount)
            {
                incomeTaxAmount = GetIncomeTaxAmount(grossSalary - noTaxationAmount);

                if (grossSalary < socialContributionsLimitAmount)
                {
                    socialContributionsAmount = GetSocialContributionsAmount(grossSalary - noTaxationAmount);
                }
                else
                {
                    socialContributionsAmount = GetSocialContributionsAmount(socialContributionsLimitAmount - noTaxationAmount);
                }

            }

            Console.WriteLine("\nYour income tax amount is {0} IDR", incomeTaxAmount);
            Console.WriteLine("\nYour social contributions amount is {0} IDR", socialContributionsAmount);
            Console.WriteLine("\nYour total tax amount is {0} IDR", incomeTaxAmount + socialContributionsAmount);

            return netSalary - socialContributionsAmount - incomeTaxAmount;
        }

        static double GetIncomeTaxAmount(double grossSalary) => (grossSalary * 10) / 100;

        static double GetSocialContributionsAmount(double grossSalary) => (grossSalary * 15) / 100;
        
        }
}
