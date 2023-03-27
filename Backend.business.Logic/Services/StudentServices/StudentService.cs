using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;


namespace Backend.business.Logic.Services.StudentServices
{
    public class StudentService
    {

        private presenceManagementDbContext ManagementPresenceDbContext;

        public StudentService(presenceManagementDbContext dataDbContext)
        {
            ManagementPresenceDbContext = dataDbContext;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            List<Student> students = ManagementPresenceDbContext.Students.Select(std => new Student()
            {
                UserId = std.UserId,
                UsersLname = std.UsersLname,
                UsersFname = std.UsersFname,
                UsersGender = std.UsersGender,
                UsersEmail = std.UsersEmail,
                UsersPassword= std.UsersPassword,
                RoleId = std.RoleId,
            }).ToList();
            return await Task.FromResult(students);
        }


        public async Task<Student?> GetStudentIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Students.Where(r => r.UserId == id).FirstOrDefault());
        }


        public async Task<Student> CreateStudentAsync(StudentsImage StudentsImages)
        {

            Student student = new Student();

            if (StudentsImages != null)
            {
                student.UsersLname = StudentsImages.UsersLname;
                student.UsersFname = StudentsImages.UsersFname;
                student.UsersGender = StudentsImages.UsersGender;
                student.UsersEmail = StudentsImages.UsersEmail;
                student.UsersPassword = BCrypt.Net.BCrypt.HashPassword(StudentsImages.UsersPassword);
                student.RoleId = 3;
                ManagementPresenceDbContext.Add(student);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return student;

            }
            return student;
        }

        public async Task<bool> UpdateStudentAsync(StudentsImage StudentsImages, int id)
        {

            Users? student = await GetStudentIdAsync(id);

            if (StudentsImages != null && student != null)
            {
                student.UserId = id;
                student.UsersLname = StudentsImages.UsersLname;
                student.UsersFname = StudentsImages.UsersFname;
                student.UsersGender = StudentsImages.UsersGender;
                student.UsersPassword = StudentsImages.UsersPassword;

                student.RoleId = 3;
                ManagementPresenceDbContext.UpdateRange(student);
                await ManagementPresenceDbContext.SaveChangesAsync();

                return true;

            }
            return false;
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await GetStudentIdAsync(id);
            if (student == null)
                return false;
            ManagementPresenceDbContext.Remove(student);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }

    }
}

