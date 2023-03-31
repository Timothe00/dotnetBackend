using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;


namespace Backend.business.Logic.Services.StudentServices
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student?> GetStudentIdAsync(int id);
        Task<Student> CreateStudentAsync(StudentsImage StudentsImages);
        Task<bool> UpdateStudentAsync(StudentsImage StudentsImages, int id);
        Task<bool> DeleteStudentAsync(int id);
    }
}
