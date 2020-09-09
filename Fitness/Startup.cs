using Fitness.Models;
using Fitness.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fitness.Startup))]
namespace Fitness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private async void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityResult roleResult;

            // In Startup iam creating first Admin Role and creating a default Admin User    


            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //IdentityResult roleResult;
                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "catnipsoft";
                user.Email = "mohammad.alnanaa@gmail.com";

                string userPWD = "Matrix__90$$";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
            string[] roleNames = {
                "Admin", "CoOwner", "CoUser" ,



                 "ShowCompany","UpdateCompany", //Company Screen
				 "ShowUser","AddUser" ,"UpdateUser","DeleteUser","PrintUser", //User Screen
                 "ShowGroup" ,"AddGroup" ,"UpdateGroup" , "DeleteGroup" , "PrintGroup" , // Group Screen
                 "ShowSource" ,"AddSource" ,"UpdateSource" , "DeleteSource" , "PrintSource" , // Source Screen
                 "ShowTrainer", "AddTrainer" , "UpdateTrainer" , "DeleteTrainer" ,"PrintTrainer" , // Trainer Screen
                 "ShowItem" , "AddItem","UpdateItem" , "UpdateItem" , "DeleteItem" , "PrintItem" , // Item Screen
                 "ShowCustomerCompany" , "AddCustomerCompany" , "UpdateCustomerCompany" , "DeleteCustomerCompany" , "PrintCustomerCompany" , // Cust Screen
                 "ShowJob" , "AddJob" , "UpdateJob"  , "DeleteJob" , "PrintJob", // Job Screen
                 "ShowNationality" , "AddNationality" , "UpdateNationality" , "DeleteNationality" , "PrintNationality" , // Nationality Screen
                 "ShowPlaceOfBirth" , "AddPlaceOfBirth" , "UpdatePlaceOfBirth" , "DeletePlaceOfBirth" , "PrintPlaceOfBirth" // Place of Birth Screen 


 
            };
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }





        }
    }
}
