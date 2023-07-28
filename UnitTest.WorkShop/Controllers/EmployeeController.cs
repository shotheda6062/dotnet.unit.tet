using Microsoft.AspNetCore.Mvc;
using UnitTest.WorkShop.Model;
using UnitTest.WorkShop.Service;

namespace UnitTest.WorkShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
            _employeeService = employeeService;

        }


        [HttpPost(Name = "CreateEmployee")]
        public void CreateEmployee(EmployeeInfo employeeInfo)
        {
            _employeeService.CreateEmployee(employeeInfo);

        }


        [HttpPost(Name = "GetEmployeeInfo")]
        public EmployeeInfo GetEmployeeInfo(string employeeID)
        {
            return _employeeService.GetEmployee(employeeID);
        }

    }
}

