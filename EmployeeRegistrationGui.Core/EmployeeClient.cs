using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationGui.Core
{
    public class EmployeeClient
    {
        private const string baseUrl = @"https://localhost:7100/";
        HttpClient client = new HttpClient();

        public EmployeeClient()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = client.GetAsync("Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
            return employees;
        }
        public async Task<bool> Delete(int id)
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = client.DeleteAsync("Employee?employeeId=" + id).Result;
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
        public async Task<bool> Post(Employee employee)
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = client.PostAsJsonAsync("Employee",employee).Result;
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
        public async Task<bool> Put(Employee employee)
        {
            IEnumerable<Employee> employees = null;
            HttpResponseMessage response = client.PutAsJsonAsync("Employee?employeeId=" + employee.Id, employee).Result;
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
