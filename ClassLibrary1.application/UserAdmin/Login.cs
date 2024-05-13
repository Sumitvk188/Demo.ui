using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.application.UserAdmin
{
   
        public class Login
        {
            private readonly UserManager<IdentityUser> userManager;
            private readonly SignInManager<IdentityUser> signInManager;

            public Login(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
            {

                this.userManager = userManager;
                this.signInManager = signInManager;
            }

            public class Request
            {
                public string Email { get; set; }
                public string Password { get; set; }
                public bool RememberMe { get; set; }
            }

            public async Task<bool> Do(Request request)
            {
                var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);

                return true;
            }

        }
    }
