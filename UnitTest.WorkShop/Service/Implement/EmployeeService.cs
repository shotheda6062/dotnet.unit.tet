using System;
using UnitTest.WorkShop.Model;
using UnitTest.WorkShop.Repository;
using UnitTest.WorkShop.Repository.Implement;

namespace UnitTest.WorkShop.Service.Implement
{
    public class EmployeeService : IEmployeeService
    {

        private const int MaxRegularHours = 120;
        private const double OvertimeMultiplier = 1.2;

        private IEmployeeRepository _employeeRepository;

        private readonly IWorkHoursRepository _workHoursRepository;

        public EmployeeService()
        {

        }

        public EmployeeService(IEmployeeRepository employeeRepository, IWorkHoursRepository workHoursRepository)
        {
            _employeeRepository = employeeRepository;
            _workHoursRepository = workHoursRepository;
        }

        public void CreateEmployee(EmployeeInfo employeeInfo)
        {
            if (GetEmployee(employeeInfo.EmployeeID) is not null) {
                throw new Exception("Employee is already exists");
            }

            _employeeRepository.InsertEmployeeInfo(employeeInfo);

        }

        public EmployeeInfo GetEmployee(string idkey)
        {
            return _employeeRepository.GetEmployeeInfo(idkey) ?? throw new NullReferenceException("Not Found EmployyInfo");
        }


        public double CalculateSalaryForEmployee(string employeeId)
        {
            int hoursWorked = _workHoursRepository.FindWorkHoursById(employeeId);
            EmployeeInfo employeeInfo = GetEmployee(employeeId);

            if (hoursWorked > MaxRegularHours)
            {
                int regularHours = MaxRegularHours;
                int overtimeHours = hoursWorked - MaxRegularHours;
                
                double salary = (regularHours * employeeInfo.hourlyRate) + (overtimeHours * employeeInfo.hourlyRate * OvertimeMultiplier);
                return salary;
            }
            else
            {
                return hoursWorked * employeeInfo.hourlyRate;
            }
        }

    }
}
