using BlazorCrud_Shared;
using System.Net.Http.Json;

namespace BlazorCrud_Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EmployeeDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<EmployeeDTO>>>("api/Employee/List");

            if (result!.IsCorrect)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<EmployeeDTO> Search(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<EmployeeDTO>>($"api/Employee/Search/{id}");

            if (result!.IsCorrect)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<int> Add(EmployeeDTO employee)
        {
            var result = await _http.PostAsJsonAsync("api/Employee/Add",employee);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsCorrect)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }      

        public async Task<int> Edit(EmployeeDTO employee)
        {
            var result = await _http.PutAsJsonAsync($"api/Employee/Edit/{employee.EmployeeId}", employee);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsCorrect)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/Employee/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsCorrect)
            {
                return response.IsCorrect!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }
    }
}
