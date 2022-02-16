using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWage
{
    internal class CalculateEmpWage
    {
        //Constant Variables.
        const int FULL_TIME = 1;
        const int PART_TIME = 2;
        //static variable
        public static int emphrs;
        //Use of List and Dictionary 
        public IList<EmpWage> CompanyEmpWge = new List<EmpWage>();
        public IDictionary<string, EmpWage> employees = new Dictionary<string, EmpWage>();

        public void AddCompany(string company, int wagePrHrs, int totalWorkHrs, int totalWorkDay)
        {
            //creating obj of EmpWage and passing constructor values
            EmpWage empWage = new EmpWage(company, wagePrHrs, totalWorkHrs, totalWorkDay);
            CompanyEmpWge.Add(empWage);       // Adding data in list
            employees.Add(company, empWage);  // Adding data in Dictionary as key value Pair

        }
         /// Gets the wage for each key
        public void GetWage()
        {
            //loop to get and set total wage for each List index
            foreach (EmpWage empWage in this.CompanyEmpWge)
            {
                empWage.SetTotalWage(WageCompute(empWage));
            }
        }

        // method to perform Employee Wage Computation program using parameters.
        public int WageCompute(EmpWage emp)
        {
            //Local Variables
            int totalWage = 0;
            int totalEmpWrkHr = 0;
            int totalEmpwrkDay = 1;

            //Creating Object of Random Class
            Random randomNum = new Random();

            //Checking condition.           
            while (totalEmpWrkHr <= emp.totalWorkHrs && totalEmpwrkDay <= emp.totalWorkDay)
            {
                int empCheck = randomNum.Next(0, 3);     //generating random number from 0 to 2.
                GetEmpHrs(empCheck);                    //calling static method to get Emp hrs.
                int empWage = emphrs * emp.wagePrHrs;
                totalWage += empWage;
                totalEmpWrkHr = emphrs + totalEmpWrkHr;      //Computing Total Work Hrs of Employee Day wise.
                totalEmpwrkDay++;                           //incrementing Number of Day Worked.
            }
            Console.WriteLine("\nEmployee of company : {0} , Total wage is : {1} ", emp.company, totalWage);
            return totalWage;
        }

        //Method to Get Employee work hours.
        public static void GetEmpHrs(int empCheck)
        {
            switch (empCheck)       //passing random number into switch to get employee work hours.
            {
                case FULL_TIME:
                    emphrs = 8;
                    break;
                case PART_TIME:
                    emphrs = 4;
                    break;
                default:
                    emphrs = 0;
                    break;
            }
        }
    }
    public class EmpWage
    {
        //Instance variables.
        public string company;
        public int wagePrHrs, totalWorkHrs, totalWorkDay, totalWage;

        //Constructor to set value for each object.
        public EmpWage(string company, int wagePrHrs, int totalWorkHrs, int totalWorkDay)
        {
            this.company = company;
            this.wagePrHrs = wagePrHrs;
            this.totalWorkHrs = totalWorkHrs;
            this.totalWorkDay = totalWorkDay;
        }

        //Method to set Total Wage of a Company.
        public void SetTotalWage(int totalWage)
        {
            this.totalWage = totalWage;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {          
            //printing message on console
            Console.WriteLine("Welcome To Employee Wage Computation Program \n");

            //Creating Object for each company and passing value to constructor.
            CalculateEmpWage company = new CalculateEmpWage();
            company.AddCompany("Dmart", 30, 120, 25);
            company.AddCompany("Reliance", 25, 125, 24);
            company.AddCompany("Amazon", 40, 110, 22);
            company.GetWage();
            Console.ReadLine();
        }
    }

}
