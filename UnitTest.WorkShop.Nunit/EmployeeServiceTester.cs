using NSubstitute.ReturnsExtensions;
using UnitTest.WorkShop.Model;
using UnitTest.WorkShop.Repository;
using UnitTest.WorkShop.Repository.Implement;
using UnitTest.WorkShop.Service;
using UnitTest.WorkShop.Service.Implement;

namespace UnitTest.WorkShop.Nunit;

public class EmployeeServiceTester
{

    private IEmployeeService _target;

    private IEmployeeRepository _stubEmployeeRepository;

    private IWorkHoursRepository _workHoursRepository;

    [SetUp]
    public void Setup()
    {
        //Mock Stub 造假一個在呼叫IEmployeeService時會掉用到的方法，進行隔離。
        _stubEmployeeRepository = Substitute.For<IEmployeeRepository>();
        _workHoursRepository = Substitute.For<IWorkHoursRepository>();
        _target = new EmployeeService(_stubEmployeeRepository, _workHoursRepository);

    }

    [Test]
    public void CreateEmployeeInfo_Fail()
    {
        // Arrange
        // 預設造假方法回傳的物件
        EmployeeInfo employeeInfo = new()
        {
            Name = "Wang",
            Mobile = "091234567"
        };

        //　造假方法預期傳入任何字串都會回傳預設的值。
        _stubEmployeeRepository.GetEmployeeInfo(Arg.Any<string>()).Returns(employeeInfo);

        // Assert
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Employee is already exists")
                      // Act
                      , () => _target.CreateEmployee(employeeInfo));

    }


    [Test] // 這個會錯 (故意的) 
    public void CreateEmployeeInfo_Success()
    {
        // Arrange
        EmployeeInfo inputParm = new()
        {
            Name = "Wang",
            Mobile = "091234567"
        };

        _stubEmployeeRepository.GetEmployeeInfo(Arg.Any<string>()).ReturnsNull();

        // Act
        _target.CreateEmployee(inputParm);

        // Assert
        _stubEmployeeRepository.Received(1).InsertEmployeeInfo(Arg.Any<EmployeeInfo>());

    }

    [Test]
    public void GetEmployeeInfo_Success()
    {
        // Arrange
        // 預設造假方法回傳的物件
        EmployeeInfo response = new()
        {
            Name = "Wang",
            Mobile = "091234567"
        };

        //　造假方法預期傳入任何字串都會回傳預設的值。
        _stubEmployeeRepository.GetEmployeeInfo(Arg.Any<string>()).Returns(response);

        // Act
        EmployeeInfo targetResponse = _target.GetEmployee("Wnag");


        // Assert
        Assert.That(targetResponse.Name, Is.EqualTo(response.Name));
    }


    [Test]
    public void GetEmployeeInfo_Error()
    {
        // Arrange
        //　造假方法預期傳入任何字串都會回傳預設的值。
        _stubEmployeeRepository.GetEmployeeInfo(Arg.Any<string>()).ReturnsNull();

        // Assert
        Assert.Throws(Is.TypeOf<NullReferenceException>().And.Message.EqualTo("Not Found EmployyInfo")
                      // Act
                      , () => _target.GetEmployee("Wnag"));

    }


}
