using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Demo.ui.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public class LoginVM
        {

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            var success = await RegisterEmp(emp);
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

        [BindProperty]
        public LoginVM emp { get; set; }

        private async Task<bool> RegisterEmp(LoginVM emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            string baseUrl = "https://localhost:7259"; // Replace with your actual base URL
            string url = baseUrl + $"/User/Login";
            var response = await _httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
