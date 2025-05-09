using Hackathon.Application.BusinessRules.Common.Interfaces;
using Hackathon.Application.BusinessRules.Common.Utility;
using Hackathon.Application.BusinessRules.Data;
using Hackathon.Application.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Infrustructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                //if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                //{
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                //    _roleManager.CreateAsync(new IdentityRole(SD.Role_Applicant)).Wait();
                //    _userManager.CreateAsync(new ApplicationUser
                //    {
                //        UserName = "Langa@Langa.com",
                //        Email = "Langa@Langa.com",
                //        Name = "Langa Shabangu",
                //        NormalizedUserName = "LANGA@LANGA.COM",
                //        NormalizedEmail = "LANGA@LANGA.COM",
                //        PhoneNumber = "1112223333",
                //    }, "Langa123*").GetAwaiter().GetResult();

                //    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Langa@Langa.com");
                //    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                //}
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
