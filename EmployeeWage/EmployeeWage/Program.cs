using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    public class EmpWageBuilderArray
    {
        const int isFullTime = 1;
        const int isPartTime = 2;

        private int numOfCompanies = 0;
        private CompanyEmpWage[] companyEmpWageArray;
       public EmpWageBuilderArray()
        {
            this.companyEmpWageArray = new CompanyEmpWage[5];
        }
        public void addCompanyEmpWage(string company,int empRatePerHr, int numOWorkingDays,int maxHrsInMonth)
        {
            companyEmpWageArray[this.numOfCompanies] = new CompanyEmpWage(company, empRatePerHr, numOWorkingDays, maxHrsInMonth);
            numOfCompanies++;
        }
        public void ComputeEmpWage()
        {
            for (int i=0;i<numOfCompanies;i++)
            {
                companyEmpWageArray[i].setTotalEmpWage(this.ComputeEmpWage(this.companyEmpWageArray[i]));
                Console.WriteLine(this.companyEmpWageArray[i].toString());
            }

        }

        private int ComputeEmpWage(CompanyEmpWage companyEmpWage)
        {
            int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;
            Random random = new Random();

            while (totalEmpHrs <= companyEmpWage.maxHrsInMonth && totalWorkingDays < companyEmpWage.numOfWorkingDays)
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

            return totalEmpHrs * companyEmpWage.empRatePerHr;
        }
    }
    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHr;
        public int numOfWorkingDays;
        public int maxHrsInMonth;
        public int totalEmpWage;
        public CompanyEmpWage(string company,int empRAtePerHr,int numOfWorkingDays,int maxWorkingHrsInMonth)
        {
            this.company = company;
            this.empRatePerHr=empRAtePerHr;
            this.numOfWorkingDays=numOfWorkingDays;
            this.maxHrsInMonth=maxWorkingHrsInMonth;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }
        public string toString()
        {
            return ($"monthly wage for {this.company}is: {this.totalEmpWage}");
        }
    }
     class Program
     {
           static void Main(string[] args)
           {
              EmpWageBuilderArray empWageBuilder=new EmpWageBuilderArray();
            empWageBuilder.addCompanyEmpWage("INFOSYS", 20, 18, 10);
            empWageBuilder.addCompanyEmpWage("IBM", 10,16, 20);
            empWageBuilder.ComputeEmpWage();
                Console.ReadLine();
           }
     }
    
}
