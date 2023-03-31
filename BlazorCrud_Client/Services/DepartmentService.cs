using BlazorCrud_Shared;
using System.Net.Http.Json;

namespace BlazorCrud_Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;

        public DepartmentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DepartmentDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DepartmentDTO>>>("api/Department/List");

            if (result!.IsCorrect) {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }
    }
}
