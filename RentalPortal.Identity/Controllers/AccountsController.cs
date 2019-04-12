using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalPortal.Identity.Data;
using RentalPortal.Identity.Entities;
using RentalPortal.Identity.Helpers;
using RentalPortal.Identity.ViewModel;


namespace RentalPortal.Identity.Controllers
{
    [Route("api/[controller]")] 
    public class AccountsController : Controller
    {
        private readonly EfDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager,EfDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = new AppUser
            {
                UserName = model.UserName,
                Email = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            return new OkObjectResult("Registration Successful");
        }

        [HttpGet("Welcome")]
        public ActionResult Welcome()
        {
            return View("Welcome");
        }
    }
}
