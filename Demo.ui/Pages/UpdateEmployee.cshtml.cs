
using Demo.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Demo.ui.Pages
{
    public class UpdateEmployeeModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public UpdateEmployeeModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Serializable]
        public class EmpVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }


        [BindProperty]
        public EmpVM emp { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var empi = await GetEmployeeById(id);

            emp = new EmpVM
            {
                Id = empi.Id,
                Name = empi.Name,
                Email = empi.Email
            };



            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            var success = await UpdateEmployee(emp);
            if (success)
            {
                // Employee updated successfully, redirect or perform other actions
                return RedirectToPage("/Index");
            }
            else
            {
                // Handle update failure
                return Page();
            }
        }

        private async Task<Employee> GetEmployeeById(int id)
        {
            string baseUrl = "https://localhost:7259"; // Replace with your actual base URL
            string url = baseUrl + $"/Employee/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<Employee>();
            return content;

        }
        private async Task<bool> UpdateEmployee(EmpVM emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            string baseUrl = "https://localhost:7259"; // Replace with your actual base URL
            string url = baseUrl + $"/Employee";
            var response = await _httpClient.PutAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
