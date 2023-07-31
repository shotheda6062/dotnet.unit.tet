using System;
using UnitTest.WorkShop.Model;
using UnitTest.WorkShop.Repository;

namespace UnitTest.WorkShop.Service.Implement
{
    public class EmployeeService : IEmployeeService
    {

        private IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
        }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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

            
    }
}
