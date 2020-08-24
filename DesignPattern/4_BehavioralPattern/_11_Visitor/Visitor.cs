using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Visitor
{
    public interface IEmployee
    {
        string Name { get; set; }
        double Income { get; set; }
        int VacationDays { get; set; }
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void VisitiEmployee(IEmployee employee);
        void VisitManager(Manager manager);
    }

    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }
        public Employee(string name, double income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitiEmployee(this);
        }
    }

    public class Manager : IEmployee
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }
        public Manager(string name, double income, int vacationDays, string department)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
            this.Department = department;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitManager(this);
        }
    }

    public class EmployeeCollection : List<IEmployee>
    {
        public void Accept(IVisitor visitor)
        {
            foreach (IEmployee employee in this)
            {
                employee.Accept(visitor);
            }
        }
    }

    public class ExtraVacationVisitor : IVisitor
    {
        public void VisitiEmployee(IEmployee employee)
        {
            employee.VacationDays += 1;
        }

        public void VisitManager(Manager manager)
        {
            manager.VacationDays += 2;
        }
    }

    public class RaiseSalaryVisitor : IVisitor
    {
        public void VisitiEmployee(IEmployee employee)
        {
            employee.Income *= 1.1;
        }

        public void VisitManager(Manager manager)
        {
            manager.Income *= 1.2;
        }
    }

    public class Test
    {
        public static void Entry()
        {
            EmployeeCollection employees = new EmployeeCollection();
            employees.Add(new Employee("joe", 25000, 14));
            employees.Add(new Manager("alice", 22000, 14, "sales"));
            employees.Add(new Employee("peter", 15000, 7));
        }
    }
}
