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
            const int empRatePerHr = 20;
            const int numOfWorkingDays = 20;
            const int maxHrsInMonth= 100;
            int empHrs = 0, empWage = 0,totalEmpHrs=0,totalWorkingDays=0,monthlyWage=0;

            while( totalEmpHrs <= maxHrsInMonth &&totalWorkingDays<numOfWorkingDays )
            {
                totalWorkingDays++;
                Random random = new Random();
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
                totalEmpHrs += empHrs;
                Console.WriteLine("Day#:" + totalWorkingDays + "Employee hours :" + empHrs);
            }
            monthlyWage = totalEmpHrs * empRatePerHr;
            Console.WriteLine("monthly wage is :" + monthlyWage);
            Console.ReadLine();
        }
    }
}
