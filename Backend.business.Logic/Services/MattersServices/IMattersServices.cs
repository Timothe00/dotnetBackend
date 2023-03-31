using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.business.Logic.Services.MattersServices
{
    public interface IMattersServices
    {
        Task<IEnumerable<Matters>> GetMattersAsync();
        Task<Matters?> GetMatterIdAsync(int id);

        Task<Matters> CreateMatterAsync(MattersImage MattersImages);
        Task<Matters> UpdateMatterAsync(MattersImage MattersImages);
        Task<bool> DeleteMatterAsync(int id);
    }
}
