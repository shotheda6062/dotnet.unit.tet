using System;
using UnitTest.WorkShop.Model;

namespace UnitTest.WorkShop.Service
{
	public interface IEmployeeService
	{

		public EmployeeInfo GetEmployee(String idkey);

		public void CreateEmployee(EmployeeInfo employeeInfo);

	}
}

