using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Employee Wage Computation Program on Master Branch");

            int isFullTime = 1;
            int isPartTime = 2;
            int empRatePerHr = 20;
            int empHrs = 0, empWage = 0;
            Random random= new Random();
            int empCheck = random.Next(0, 3);
            if (empCheck == isFullTime)
            {
                Console.WriteLine("Employee is present FullTime ");
                empHrs = 8;
            }
            else if (empCheck == isPartTime)
            {
                Console.WriteLine("Employee is present PartTime");
                empHrs = 4;
            }
            else
            {
                Console.WriteLine("Employee is absent");
                empHrs = 0;
            }
            empWage = empHrs * empRatePerHr;
            Console.WriteLine("Employee wage is : " + empWage);
            Console.ReadLine();
        }
    }
}
