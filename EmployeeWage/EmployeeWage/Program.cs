using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class Program
    {
        const int isFullTime = 1;
        const int isPartTime = 2;
       
        int empHrs = 0,  totalEmpHrs = 0, totalWorkingDays = 0, monthlyWage = 0;
        Random random = new Random();

        public int EmployeeWages(string company, int empRatePerHr, int numOfWorkingDays, int maxHrsInMonth)
        {
            while (totalEmpHrs <= maxHrsInMonth && totalWorkingDays < numOfWorkingDays)
            {
                totalWorkingDays++;
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
           // return monthlyWage;
            monthlyWage = totalEmpHrs * empRatePerHr;
            Console.WriteLine($"monthly wage for {company}is: { monthlyWage}");
            return monthlyWage;
            
        }
         static void Main(string[] args)
         {
            Program employee = new Program();
            employee.EmployeeWages("Tcs", 20, 18, 100);            
            employee.EmployeeWages("Accenture", 22, 22, 80);
            employee.EmployeeWages("IBM", 50, 15, 100);
            Console.ReadLine();
         }
    }
}
