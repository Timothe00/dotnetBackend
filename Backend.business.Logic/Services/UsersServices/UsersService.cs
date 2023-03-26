using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.business.Logic.Services.UsersServices
{
    public class UsersService
    {
        private presenceManagementDbContext ManagementPresenceDbContext;

        public UsersService(presenceManagementDbContext dataDbContext) 
        {
            ManagementPresenceDbContext = dataDbContext;
        }



        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {

            List<Users> users = ManagementPresenceDbContext.Users.Select(users => new Users()
            {
                UserId = users.UserId,
                UsersLname = users.UsersLname,
                UsersFname = users.UsersFname,
                UsersGender = users.UsersGender,
                UsersEmail = users.UsersEmail,
                UsersPassword = users.UsersPassword,
                RoleId = users.RoleId,
            }).ToList();

            return await Task.FromResult(users);
        } 

        public async Task<Users?> GetUserByIdAsync(int id)
        {
            Users userById = await ManagementPresenceDbContext.Users.FindAsync(id);
            if (userById == null)
            {
                return null;
            }

            return userById;
        }



        public async Task<Users> CreateUserAsync(ImagePost UsersImages)
        {
            Users users = new Users();
            Student student = new Student();
            Admin admin = new Admin();
            Teacher teacher = new Teacher();


            if (UsersImages != null)
            {
                if (UsersImages.RoleId == 1)
                {
                    admin.UsersLname = UsersImages.UserLname;
                    admin.UsersFname = UsersImages.UserFname;
                    admin.UsersGender = UsersImages.UserGender;
                    admin.UsersEmail = UsersImages.UserEmail;
                    admin.UsersPassword = UsersImages.UserPassword;
                    admin.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Add(admin);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return admin;

                }
                else if (UsersImages.RoleId == 2)
                {
                    teacher.UsersLname = UsersImages.UserLname;
                    teacher.UsersFname = UsersImages.UserFname;
                    teacher.UsersGender = UsersImages.UserGender;
                    teacher.UsersEmail = UsersImages.UserEmail;
                    teacher.UsersPassword = UsersImages.UserPassword;
                    teacher.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Add(teacher);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return teacher;
                }
                else if (UsersImages.RoleId == 3)
                {
                    student.UsersLname = UsersImages.UserLname;
                    student.UsersFname = UsersImages.UserFname;
                    student.UsersGender = UsersImages.UserGender;
                    student.UsersEmail = UsersImages.UserEmail;
                    student.UsersPassword = UsersImages.UserPassword;
                    student.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Add(student);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return student;

                }
                return users;
            }
            return users;

        }


        public async Task<Users> UpdateUserAsync(ImagePost UsersImages)
        {
            Users user = new Users();
            Student student = new Student();
            Admin admin = new Admin();
            Teacher teacher = new Teacher();

            if (UsersImages != null)
            {
                if (UsersImages.RoleId == 1)
                {
                    admin.UsersLname = UsersImages.UserLname;
                    admin.UsersFname = UsersImages.UserFname;
                    admin.UsersGender = UsersImages.UserGender;
                    admin.UsersEmail = UsersImages.UserEmail;
                    admin.UsersPassword = UsersImages.UserPassword;
                    admin.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Update(admin);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return admin;

                }
                else if (UsersImages.RoleId == 2)
                {
                    teacher.UsersLname = UsersImages.UserLname;
                    teacher.UsersFname = UsersImages.UserFname;
                    teacher.UsersGender = UsersImages.UserGender;
                    teacher.UsersEmail = UsersImages.UserEmail;
                    teacher.UsersPassword = UsersImages.UserPassword;
                    teacher.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Update(teacher);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return teacher;
                }
                else if (UsersImages.RoleId == 3)
                {
                    student.UsersLname = UsersImages.UserLname;
                    student.UsersFname = UsersImages.UserFname;
                    student.UsersGender = UsersImages.UserGender;
                    student.UsersEmail = UsersImages.UserEmail;
                    student.UsersPassword = UsersImages.UserPassword;
                    student.RoleId = UsersImages.RoleId;
                    ManagementPresenceDbContext.Update(student);
                    await ManagementPresenceDbContext.SaveChangesAsync();
                    return student;

                }
                return user;
            }
            return user;
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user == null)
                return false;
            ManagementPresenceDbContext.Remove(user);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }

    }
}
