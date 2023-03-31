using BlazorCrud_Shared;

namespace BlazorCrud_Client.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> List();
    }
}
