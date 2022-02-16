using EmployeeWage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    public interface IComputeEmpWage
    {
        //Interface
        void addCompanyEmpWage(string company, int empRatePerHr, int numOfWorkingDays, int maxHrsPerMonth);
         void computeEmpWage();
         int getTotalWage(string company);

    }
    public class CompanyEmpWage
    {
        public string company;
        public int empRatePerHr;
        public int numOfWorkingDays, maxHrsPerMonth, totalEmpWage;
        public CompanyEmpWage(string company, int empRatePerHr, int numOfWorkingDays, int maxHrsPerMonth)
        {
            this.company = company;
            this.empRatePerHr = empRatePerHr;
            this.numOfWorkingDays = numOfWorkingDays;
            this.maxHrsPerMonth = maxHrsPerMonth;
            this.totalEmpWage = 0;
        }
        public void setTotalEmpWage(int totalEmpWage)
        {
            this.totalEmpWage = totalEmpWage;
        }
        public string toString()
        {
            return "Total emp wage for company :" + this.company + "is :" + this.totalEmpWage;
        }
    }
    public class EmpWageBuilder //: IComputeEmpWage
    {
        //Constant Variables.
        const int Is_FULL_TIME = 1;
        const int Is_PART_TIME = 2;

        //Use of List and Dictionary 
        public LinkedList<CompanyEmpWage> companyEmpWageList;
        public Dictionary<string, CompanyEmpWage> companyToEmpWageMap;

        public EmpWageBuilder()
        {
            this.companyEmpWageList = new LinkedList<CompanyEmpWage>();
            this.companyToEmpWageMap = new Dictionary<string, CompanyEmpWage>();
        }

        public void addCompanyEmpWage(string company, int empRatePerHr, int numOfWorkingDays, int maxHrsPerMonth)
        {
            //creating obj of EmpWage and passing constructor values
            CompanyEmpWage companyEmpWage = new CompanyEmpWage(company, empRatePerHr, numOfWorkingDays, maxHrsPerMonth);
            this.companyEmpWageList.AddLast(companyEmpWage);       // Adding data in list
            this.companyToEmpWageMap.Add(company, companyEmpWage);  // Adding data in Dictionary as key value Pair

        }
        /// Gets the wage for each key
        public void computeEmpWage()
        {
            //loop to get and set total wage for each List index
            foreach (CompanyEmpWage companyEmpWage in this.companyEmpWageList)
            {
                companyEmpWage.setTotalEmpWage(this.ComputeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.toString());
            }
        }
        public int ComputeEmpWage(CompanyEmpWage companyEmpWage)
        {
            int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;
            Random random = new Random();

            while (totalEmpHrs <= companyEmpWage.maxHrsPerMonth && totalWorkingDays < companyEmpWage.numOfWorkingDays)
            {
                totalWorkingDays++;
                int empCheck = random.Next(0, 3);
                switch (empCheck)
                {
                    case Is_FULL_TIME:
                        empHrs = 8;
                        break;
                    case Is_PART_TIME:
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

        public int GetTotalWage(string company)
        {
            return this.companyToEmpWageMap[company].totalEmpWage;
        }
    }
   
}
class Program
{
  static void Main(string[] args)
  {          
            //printing message on console
    Console.WriteLine("Welcome To Employee Wage Computation Program \n");
        //Creating Object for each company and passing value to constructor.
        EmpWageBuilder empWageBuilder = new EmpWageBuilder();
        empWageBuilder.addCompanyEmpWage("IBM",20,2,10);
        empWageBuilder.addCompanyEmpWage("INFOSYS", 10, 4, 20);
        empWageBuilder.computeEmpWage();
        Console.WriteLine("Total wage for IBM company :"  +empWageBuilder.GetTotalWage("IBM"));
        Console.ReadLine();      
  }

}

