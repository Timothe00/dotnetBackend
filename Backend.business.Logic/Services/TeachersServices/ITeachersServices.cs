using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;

namespace Backend.business.Logic.Services.TeachersServices
{
    public interface ITeachersServices
    {
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher?> GetTeacherIdAsync(int id);
        Task<Teacher> CreateTeacherAsync(TeacherImage TeacherImages);
        Task<bool> UpdateTeacherAsync(TeacherImage TeacherImages, int id);
        Task<bool> DeleteTeacherAsync(int id);
    }
}