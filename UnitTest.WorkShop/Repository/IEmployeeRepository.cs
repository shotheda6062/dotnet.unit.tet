using System;
using UnitTest.WorkShop.Model;

namespace UnitTest.WorkShop.Repository
{
	public interface IEmployeeRepository
	{

		public void InsertEmployeeInfo(EmployeeInfo employee);


		public EmployeeInfo? GetEmployeeInfo(string employeeID);

	}
}

