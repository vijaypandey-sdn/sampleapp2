using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Repository;

namespace SampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        public ValuesController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // I am writing this method to get the list of all employees
            try
            {
                var employeeList = _testRepository.GetEmployees();
                if (employeeList.Any())
                    return Ok(employeeList);
                else
                    return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("HighestSalary/{department}")]
        public IActionResult Get(string department)
        {
            // I am writing this method to get the employee with highest salary.
            try
            {
                if (string.IsNullOrEmpty(department))
                    return BadRequest($"Invalid department {department}");
                var employeeList = _testRepository.GetEmployees();
                if (employeeList.Any())
                {
                    var highestSalary = employeeList.Where(a => a.Department?.ToLower() == department?.ToLower()).OrderByDescending(a => a.Salary)?.FirstOrDefault();
                    if(highestSalary!=null)
                        return Ok(highestSalary);
                    else
                        return NotFound($"Employee not found of the entered department {department}");
                }
                else
                   return NotFound();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
