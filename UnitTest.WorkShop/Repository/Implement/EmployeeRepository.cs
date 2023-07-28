using System;
using System.Collections.Generic;
using UnitTest.WorkShop.Model;

namespace UnitTest.WorkShop.Repository.Implement
{
	public class EmployeeRepository : IEmployeeRepository
	{

        private Dictionary<string, EmployeeInfo> _employeeMap = new();


        public EmployeeInfo? GetEmployeeInfo(string employeeID)
        {
            return _employeeMap.GetValueOrDefault(employeeID);
        }

        public void InsertEmployeeInfo(EmployeeInfo employee)
        {
            throw new NotImplementedException();
        }
    }
}

