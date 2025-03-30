using efCrud.Entity;

namespace efCrud.Services.IManager
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> AddEmployee(EmployeeDto employeeDto);
        Task DeleteEmployee(Guid id);
        Task UpdateEmployee(Guid id,EmployeeDto employee);

    }
}
