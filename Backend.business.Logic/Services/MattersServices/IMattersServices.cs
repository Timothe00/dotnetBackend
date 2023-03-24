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
        IEnumerable<Matters> GetMattersAsync();
        Task<Matters?> GetMatterAsync(int id);
        Task<Matters> UpdateMatterAsync(MattersImage MattersImages);
        Task<bool> DeleteMatterAsync(int id);
    }
}
