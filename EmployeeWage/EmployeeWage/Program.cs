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

            const int isFullTime = 1;
            const int isPartTime = 2;
            int empRatePerHr = 20;
            int empHrs = 0, empWage = 0;
            Random random= new Random();
            int empCheck = random.Next(0, 3);
           switch (empCheck)
            {
                case isFullTime:
                    empHrs = 8;
                    break;
                    case isPartTime:
                    empHrs = 4;
                    break;
                    default:
                    empHrs = 0;
                    break;
            }
            empWage = empHrs * empRatePerHr;
            Console.WriteLine("Employee wage is : " + empWage);
            Console.ReadLine();
        }
    }
}
