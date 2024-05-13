using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Demo.ui.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public RegisterModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Serializable]
        public class EmpVM
        {
            [Required]
            [EmailAddress]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Passowrd")]
            [Compare("Password", ErrorMessage = "Password and confirmation don't match")]
            public string ConfirmPassword { get; set; }
        }


        [BindProperty]
        public EmpVM emp { get; set; }


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

        private async Task<bool> RegisterEmp(EmpVM emp)
        {
            var json = JsonConvert.SerializeObject(emp);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            string baseUrl = "https://localhost:7259"; // Replace with your actual base URL
            string url = baseUrl + $"/User";
            var response = await _httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
