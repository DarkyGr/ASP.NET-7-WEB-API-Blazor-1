using BlazorCrud_Shared;

namespace BlazorCrud_Client.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> List();

        Task<EmployeeDTO> Search(int id);

        Task<int> Add(EmployeeDTO employee);

        Task<int> Edit(EmployeeDTO employee);

        Task<bool> Delete(int id);
    }
}
