using efCrud.dbconnect;
using efCrud.Entity;
using efCrud.Services.IManager;
using Microsoft.EntityFrameworkCore;

namespace efCrud.Services.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeManager(ApplicationDbContext dbContext) 
        {
            _dbcontext = dbContext;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbcontext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployee(Guid id)
        {
            return await _dbcontext.Employees.FindAsync(id);
        }
        public async Task<Employee> AddEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Address = employeeDto.Address,
                City = employeeDto.City,
                PostalCode = employeeDto.PostalCode,
                Department = employeeDto.Department,
                JobTitle = employeeDto.JobTitle
            };
            _dbcontext.Employees.Add(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _dbcontext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbcontext.Employees.Remove(employee);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task UpdateEmployee(Guid id, EmployeeDto employeeDto)
        {
            var emp = await _dbcontext.Employees.FindAsync(id);
            if (emp != null)
            {
                emp.Name = employeeDto.Name;
                emp.Email = employeeDto.Email;
                emp.PhoneNumber = employeeDto.PhoneNumber;
                emp.Address = employeeDto.Address;
                emp.City = employeeDto.City;
                emp.PostalCode = employeeDto.PostalCode;
                emp.Department = employeeDto.Department;
                emp.JobTitle = employeeDto.JobTitle;

                _dbcontext.Employees.Update(emp);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
