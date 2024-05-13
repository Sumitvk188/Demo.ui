using Demo.application.Employee;
using Demo.database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.ui.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly Appdbcontext _ctx;
        public AddEmployeeModel(Appdbcontext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public CreateEmployee.Request request { get; set; }
        public async Task<IActionResult> OnPost()
        {


            // Call the service or logic to create the employee (replace with your logic)
            await new CreateEmployee(_ctx).Do(request);

            // Handle successful creation (e.g., redirect to another page)
            return RedirectToPage("Index");
        }
        
    }
}
