/* Exercise-2 code */
// using Microsoft.AspNetCore.Mvc;

// namespace MyFirstWebAPI.Controllers
// {
//     [ApiController]
//     [Route("api/Emp")]
//     public class EmployeeController : ControllerBase
//     {
//         [HttpGet]
//         public ActionResult<string> Get()
//         {
//             return Ok("Employee data retrieved successfully");
//         }
//     }
// }

/* Exercise-3 */
// using Microsoft.AspNetCore.Mvc;
// using MyFirstWebAPI.Models;
// using MyFirstWebAPI.Filters;

// namespace MyFirstWebAPI.Controllers
// {
//     [CustomAuthFilter]
//     [ApiController]
//     [Route("api/[controller]")]
//     public class EmployeeController : ControllerBase
//     {
//         private static List<Employee> _employees = new List<Employee>();

//         public EmployeeController()
//         {
//             if (_employees.Count == 0)
//             {
//                 _employees = GetStandardEmployeeList();
//             }
//         }

//         [HttpGet]
//         [ProducesResponseType(typeof(List<Employee>), 200)]
//         public ActionResult<List<Employee>> Get()
//         {
//             return Ok(_employees);
//         }

//         [HttpGet("test-exception")]
//         [ProducesResponseType(500)]
//         public ActionResult TestException()
//         {
//             throw new Exception("This is a test exception for demonstration");
//         }

//         [HttpGet("{id}")]
//         [ProducesResponseType(typeof(Employee), 200)]
//         [ProducesResponseType(404)]
//         public ActionResult<Employee> Get(int id)
//         {
//             var employee = _employees.FirstOrDefault(e => e.Id == id);
//             if (employee == null)
//                 return NotFound($"Employee with ID {id} not found");
//             return Ok(employee);
//         }

//         [HttpPost]
//         [ProducesResponseType(typeof(Employee), 201)]
//         [ProducesResponseType(400)]
//         public ActionResult<Employee> Post([FromBody] Employee employee)
//         {
//             if (employee == null)
//                 return BadRequest("Employee data is required");

//             employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
//             _employees.Add(employee);
//             return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
//         }

//         [HttpPut("{id}")]
//         [ProducesResponseType(typeof(Employee), 200)]
//         [ProducesResponseType(400)]
//         [ProducesResponseType(404)]
//         public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
//         {
//             if (id <= 0)
//                 return BadRequest("Invalid employee id");
//             if (employee == null)
//                 return BadRequest("Employee data is required");
//             if (string.IsNullOrWhiteSpace(employee.Name))
//                 return BadRequest("Employee name is required");
//             if (employee.Salary <= 0)
//                 return BadRequest("Employee salary must be greater than 0");
//             if (employee.Department == null || string.IsNullOrWhiteSpace(employee.Department.Name))
//                 return BadRequest("Employee department is required");

//             var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
//             if (existingEmployee == null)
//                 return BadRequest("Invalid employee id");

//             existingEmployee.Name = employee.Name;
//             existingEmployee.Salary = employee.Salary;
//             existingEmployee.Permanent = employee.Permanent;
//             existingEmployee.Department = employee.Department;
//             existingEmployee.Skills = employee.Skills;
//             existingEmployee.DateOfBirth = employee.DateOfBirth;

//             return Ok(existingEmployee);
//         }

//         [HttpDelete("{id}")]
// [ProducesResponseType(200)]
// [ProducesResponseType(400)]
// [ProducesResponseType(404)]
// public ActionResult Delete(int id)
// {
//     // Check if id is valid
//     if (id <= 0)
//         return BadRequest("Invalid employee id");
    
//     // Find existing employee
//     var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
//     if (existingEmployee == null)
//         return BadRequest("Invalid employee id");
    
//     // Remove employee
//     _employees.Remove(existingEmployee);
    
//     return Ok($"Employee with ID {id} has been deleted successfully");
// }

//         private List<Employee> GetStandardEmployeeList()
//         {
//             return new List<Employee>
//             {
//                 new Employee
//                 {
//                     Id = 1,
//                     Name = "John Doe",
//                     Salary = 50000,
//                     Permanent = true,
//                     Department = new Department { Id = 1, Name = "IT" },
//                     Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "ASP.NET" } },
//                     DateOfBirth = new DateTime(1990, 1, 1)
//                 },
//                 new Employee
//                 {
//                     Id = 2,
//                     Name = "Jane Smith",
//                     Salary = 60000,
//                     Permanent = false,
//                     Department = new Department { Id = 2, Name = "HR" },
//                     Skills = new List<Skill> { new Skill { Id = 3, Name = "Management" }, new Skill { Id = 4, Name = "Communication" } },
//                     DateOfBirth = new DateTime(1985, 5, 15)
//                 },
//                 new Employee
//                 {
//                     Id = 3,
//                     Name = "Bob Johnson",
//                     Salary = 55000,
//                     Permanent = true,
//                     Department = new Department { Id = 1, Name = "IT" },
//                     Skills = new List<Skill> { new Skill { Id = 5, Name = "JavaScript" }, new Skill { Id = 6, Name = "React" } },
//                     DateOfBirth = new DateTime(1988, 12, 10)
//                 }
//             };
//         }
//     }
// }

//Exercise-5

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
// using MyFirstWebAPI.Filters; // No longer needed for JWT

namespace MyFirstWebAPI.Controllers
{
    // ====== AUTHORIZATION OPTIONS ======
    [Authorize] // Any authenticated user

    // [Authorize(Roles = "POC")] // Only users with "POC" role

    // [Authorize(Roles = "Admin,POC")] // Users with "Admin" OR "POC" roles
    // ===================================

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>();

        public EmployeeController()
        {
            if (_employees.Count == 0)
            {
                _employees = GetStandardEmployeeList();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(_employees);
        }

        [HttpGet("test-exception")]
        [ProducesResponseType(500)]
        public ActionResult TestException()
        {
            throw new Exception("This is a test exception for demonstration");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), 201)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");
            if (employee == null)
                return BadRequest("Employee data is required");
            if (string.IsNullOrWhiteSpace(employee.Name))
                return BadRequest("Employee name is required");
            if (employee.Salary <= 0)
                return BadRequest("Employee salary must be greater than 0");
            if (employee.Department == null || string.IsNullOrWhiteSpace(employee.Department.Name))
                return BadRequest("Employee department is required");

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return BadRequest("Invalid employee id");

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return Ok(existingEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return BadRequest("Invalid employee id");

            _employees.Remove(existingEmployee);

            return Ok($"Employee with ID {id} has been deleted successfully");
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "ASP.NET" } },
                    DateOfBirth = new DateTime(1990, 1, 1)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "HR" },
                    Skills = new List<Skill> { new Skill { Id = 3, Name = "Management" }, new Skill { Id = 4, Name = "Communication" } },
                    DateOfBirth = new DateTime(1985, 5, 15)
                },
                new Employee
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    Salary = 55000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 5, Name = "JavaScript" }, new Skill { Id = 6, Name = "React" } },
                    DateOfBirth = new DateTime(1988, 12, 10)
                }
            };
        }
    }
}
