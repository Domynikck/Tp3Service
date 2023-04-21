using Labo8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace Labo8.Data
{
    public class UserService
    {
        readonly UserManager<User> UserManager;
        protected readonly Labo8Context _context;
        public UserService(UserManager<User> userManager, Labo8Context context)
        {
            UserManager = userManager;
            _context = context;
        }



        public async Task Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                throw new Exception("Les deux mots de passe spécifiés sont différents");
            }

            User user = new User()
            {
                UserName = register.UserName,
                Email = register.Email
            };

            IdentityResult identityResult = await this.UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                throw new Exception("La création de l'utilisateur a échoué");
            }

            
        }



    }
}
