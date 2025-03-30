using efCrud.Entity;
using efCrud.Services.IManager;
using Microsoft.AspNetCore.Mvc;

namespace efCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeManager.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _employeeManager.GetEmployee(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            var employee = await _employeeManager.AddEmployee(employeeDto);
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeDto employee)
        {
            await _employeeManager.UpdateEmployee(id, employee);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await Task.Run(() => _employeeManager.DeleteEmployee(id));
            return Ok();
        }
    }
}
