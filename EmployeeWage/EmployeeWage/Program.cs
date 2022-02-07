using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    public class Program
    {
        const int isFullTime = 1;
        const int isPartTime = 2;
        int empRatePerHr;
        int maxHrsInMonth=100;
        int numOfWorkingDays=20;
        string company;
        int empHrs = 0, totalEmpHrs = 0, totalWorkingDays =0, monthlyWage = 0;
        Random random = new Random();
        public Program(string company, int empRatePerHr, int numOfWorkingDays, int maxHrsInMonth)
        {
            this.company = company;
            this.empRatePerHr = empRatePerHr;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxHrsInMonth = maxHrsInMonth;
        }

        public void EmployeeWages()
        {
            while (totalEmpHrs <=this. maxHrsInMonth && totalWorkingDays < this. numOfWorkingDays)
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

            monthlyWage = totalEmpHrs * empRatePerHr;                    

        }
        public string toString()
        {
            return ($"monthly wage for {company}is: { monthlyWage}");
        }
    }
     class Emp
     {
           static void Main(string[] args)
           {
              Program TCS = new Program("Tcs", 20, 18, 100);
               TCS.EmployeeWages();
            Console.WriteLine(TCS.toString());

               Program INFOSYS = new Program("INFOSYS", 30, 18, 100);
               INFOSYS.EmployeeWages();
            Console.WriteLine(INFOSYS.toString());
                Console.ReadLine();
           }
     }
    
}
