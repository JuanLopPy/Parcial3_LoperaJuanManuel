using Parcial3.DAL.Entities;
using Parcial3.Enum;
using Parcial3.Helpers;
using Parcial3.Services;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Parcial3.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        private readonly IUserHelper _userHelper;

        public SeederDb(DataBaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync() { 
        await _context.Database.EnsureCreatedAsync();
            await PopulateRolesAsync();
            await PopulateUserAsync("Juan", "Lopera", "Juan_lop_admin@yopmail.com", "1234", "Robledo", "1220", UserType.Admin);
            await PopulateUserAsync("Sofia", "salazar", "sofi_user@yopmail.com", "123", "Poblado", "12", UserType.User);
            await PopulateServicesAsync();
            await _context.SaveChangesAsync();
        }

        private async Task PopulateRolesAsync()
        {
            await _userHelper.AddRoleAsync(UserType.Admin.ToString());
            await _userHelper.AddRoleAsync(UserType.User.ToString());

        }

        private async Task PopulateUserAsync(string firstName, string lastName, string email, string phone, string address, string document, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {


                user = new User
                {

                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,

                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Service { Name = "Lavada simple", Price = 25000 });
                _context.Services.Add(new Service { Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Service { Name = "Lavada + Aspirada de Cojinería", Price = 30000 });
                _context.Services.Add(new Service { Name = "Lavada Full", Price = 65000 });
                _context.Services.Add(new Service { Name = "Lavada en seco del Motor", Price = 80000 });
                _context.Services.Add(new Service { Name = "Lavada Chasis", Price = 90000 });

                await _context.SaveChangesAsync();
            }
         

            


        }




    }
}
