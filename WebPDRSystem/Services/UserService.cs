using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace WebPDRSystem.Services
{
    public interface IUserService
    {
        Task<(bool, Pdrusers)> ValidateUserCredentialsAsync(string username, string password);
        void ChangePasswordAsync(Pdrusers user, string newPassword);

        //Task<bool> RegisterSupportAsync(AddSupportViewModel model);

        Task<bool> RegisterDoctorAsync(Pdrusers model);

    }
    public class UserService : IUserService
    {
        private readonly WebPDRContext _context;

        public PasswordHasher<Pdrusers> _hashPassword = new PasswordHasher<Pdrusers>();

        

        public UserService(WebPDRContext context)
        {
            _context = context;
        }

        public async Task<(bool, Pdrusers)> ValidateUserCredentialsAsync(string username, string password)
        {
            Pdrusers user = null;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return (false, user);

            user = await _context.Pdrusers
                .SingleOrDefaultAsync(x => x.Username.Equals(username));

            if (user == null)
                return (false, user);
            /*else//Added temporarily
                return (true, user);*/

            else
            {
                try
                {
                    var result = _hashPassword.VerifyHashedPassword(user, user.Password, password);
                    if (result.Equals(PasswordVerificationResult.Success))
                    {
                        _context.Update(user);
                        return (true, user);
                    }
                    else
                        return (false, user);
                }
                catch
                {
                    return (false, user);
                }
            }
            
        }

        public void ChangePasswordAsync(Pdrusers user, string newPassword)
        {
            var hashedPassword = _hashPassword.HashPassword(user, newPassword);

            user.Password = hashedPassword;
            user.UpdatedAt = DateTime.Now;

            _context.Update(user);
            _context.SaveChanges();
        }


        public Task<bool> RegisterDoctorAsync(Pdrusers model)
        {
            if (_context.Pdrusers.Any(x => x.Username.Equals(model.Username)))  
            {
                return Task.FromResult(false);
            }
            else
            {
                string hashedPass = _hashPassword.HashPassword(model, model.Password);
                model.Password = hashedPass;
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                _context.Add(model);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
        }

    }
}
