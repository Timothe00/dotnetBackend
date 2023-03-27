using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;

namespace Backend.business.Logic.Services.TeachersServices
{
    public class TeachersService:ITeachersServices
    {
        private presenceManagementDbContext ManagementPresenceDbContext;

        public TeachersService(presenceManagementDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            List<Teacher> teachers = ManagementPresenceDbContext.Teachers.Select(teacher => new Teacher()
            {
                UserId = teacher.UserId,
                UsersLname = teacher.UsersLname,
                UsersFname = teacher.UsersFname,
                UsersGender = teacher.UsersGender,
                UsersEmail = teacher.UsersEmail,
                UsersPassword= teacher.UsersPassword,
                RoleId = teacher.RoleId,
            }).ToList();
            return await Task.FromResult(teachers);
        }


        public async Task<Teacher?> GetTeacherIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Teachers.Where(r => r.UserId == id).FirstOrDefault());
        }


        public async Task<Teacher> CreateTeacherAsync(TeacherImage TeacherImages)
        {

            Teacher teacher = new Teacher();

            if (TeacherImages != null)
            {
                teacher.UsersLname = TeacherImages.UsersLname;
                teacher.UsersFname = TeacherImages.UsersFname;
                teacher.UsersGender = TeacherImages.UsersGender;
                teacher.UsersEmail = TeacherImages.UsersEmail;
                teacher.UsersPassword = BCrypt.Net.BCrypt.HashPassword(TeacherImages.UsersPassword);
                teacher.RoleId = 2;
                ManagementPresenceDbContext.Add(teacher);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return teacher;

            }
            return teacher;
        }
        


         public async Task<bool> UpdateTeacherAsync(TeacherImage TeacherImages, int id)
        {

            Teacher? teacher = await GetTeacherIdAsync(id);

            if (TeacherImages != null && teacher != null)
            {
                teacher.UserId = id;
                teacher.UsersLname = TeacherImages.UsersLname;
                teacher.UsersFname = TeacherImages.UsersFname;
                teacher.UsersGender = TeacherImages.UsersGender;
                teacher.UsersPassword = TeacherImages.UsersPassword;

                teacher.RoleId = 2;
                ManagementPresenceDbContext.UpdateRange(teacher);
                await ManagementPresenceDbContext.SaveChangesAsync();

                return true;

            }
            return false;
        }


        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await GetTeacherIdAsync(id);
            if (teacher == null)
                return false;
            ManagementPresenceDbContext.Remove(teacher);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }

    }
}