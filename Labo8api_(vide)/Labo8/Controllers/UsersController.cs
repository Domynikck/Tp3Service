using Labo8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Labo8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;
        public UsersController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Les deux mots de passe spécifiés sont différents" });
            }

            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email
            };

            IdentityResult identityResult = await this.UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "La création de l'utilisateur a échoué" });
            }

            return Ok(new {Message = "Inscription réussi"});
        }

        [HttpPost]
        public async Task<ActionResult> Login(RegisterDTO register)
        {
            return Ok(new { Message = "Login réussi" });
        }


    }
}
