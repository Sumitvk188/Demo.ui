using Demo.database;
using Demo.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.ui.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        private readonly Appdbcontext ctx;

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                string baseUrl = "https://localhost:7259"; // Replace with your actual base URL
                string url = baseUrl + "/Employee";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Check for successful response

                var emp = await response.Content.ReadFromJsonAsync<List<Employee>>();
                Employees = emp.Select(x =>
                    new EmployeeVM
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                    }
                    );


            }
            catch (HttpRequestException ex)
            {
                // Handle exceptions appropriately, e.g., display an error message
                return Content("Error retrieving employees: " + ex.Message);
            }
            return Page();
        }

        public IEnumerable<EmployeeVM> Employees { get; set; }

        public class EmployeeVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
