using System.Threading.Tasks;
using OmniMasterFX.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using OmniMasterFX.Auth;
using Microsoft.Extensions.Options;
using OmniMasterFX.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using OmniMasterFX.Application.Identity;

namespace OmniMasterFX.WebUI.Controllers
{
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AccountController
            (
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<int>> Index()
        {
            return -1;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> PostRegister([FromBody]RegisterUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { 
                UserName = model.Username, 
                Email = model.Email, 
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            string role = "Basic User";

            if (result.Succeeded)
            {
                if (await _roleManager.FindByNameAsync(role) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("firstName", user.FirstName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("lastName", user.LastName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));

                return Ok(new Profile(user));
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginUser model)
        {
            var u = await _userManager.FindByNameAsync(model.Username);
            if(u != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(u, model.Password, false);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}