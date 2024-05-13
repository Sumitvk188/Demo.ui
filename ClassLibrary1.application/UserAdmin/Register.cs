using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.UserAdmin
{
    public class Register
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public Register(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public class Request
        {

            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }
        public async Task<bool> Do(Request request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,
            };
            var result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

            }
            return true;
        }
    }
}
