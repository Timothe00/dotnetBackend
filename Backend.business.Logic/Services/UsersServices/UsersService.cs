using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;

namespace Backend.business.Logic.Services.UsersServices
{
    public class UsersService
    {
        private ManagementPresenceDbContext? ManagementPresenceDbContext;

        public UsersService(ManagementPresenceDbContext dataDbContext) 
        {
            ManagementPresenceDbContext = dataDbContext;
        }


        public IEnumerable<Users> GetAllUsers()
        {
            return ManagementPresenceDbContext.Users.ToList();
        }

        public Users GetUsersById(int id)
        {
            Users userById = ManagementPresenceDbContext.Users.Where(pers => pers.UserId == id).FirstOrDefault();

            if (userById == null)
            {
                return null;
            }

            return userById;
        }


        public Users? AddUser(Users user)
        {
            var Tuser = ManagementPresenceDbContext.Add(user);
            if (Tuser != null)
            {
                ManagementPresenceDbContext.SaveChanges();
                return Tuser.Entity;
            }
            return null;
        }


        public Users? UserUpdate(Users Xuser)
        {
            var user = ManagementPresenceDbContext.Users.Update(Xuser);

            if (user != null)
            {
                Users Yuser = new Users();
                Yuser.RoleId = Xuser.RoleId;
                Yuser.UsersLname = Xuser.UsersLname;
                Yuser.UsersFname = Xuser.UsersFname;
                Yuser.UsersEmail = Xuser.UsersEmail;
                Yuser.UsersGender = Xuser.UsersGender;
                Yuser.UsersPassword = Xuser.UsersPassword;
                ManagementPresenceDbContext.Users.Update(Xuser);
                ManagementPresenceDbContext.SaveChanges();
                return Xuser;
            }

            return null;

        }

        public bool UserDelete(int id)
        {
            Users Xuser = GetUsersById(id);
            if (Xuser != null)
            {
                var Xus = ManagementPresenceDbContext.Users.Remove(Xuser);

                if (Xus != null)
                {
                    ManagementPresenceDbContext.SaveChanges();
                }

                return false;
            }
            else
            {
                throw new NotImplementedException();
            }

        }


    }
}
