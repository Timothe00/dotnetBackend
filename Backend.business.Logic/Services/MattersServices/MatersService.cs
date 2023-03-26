
using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.MattersServices;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Web.Mvc;

namespace Backend.business.Logic.Services.MatersServices
{
    public class MatersService 
    {
        private presenceManagementDbContext ManagementPresenceDbContext;
        public MatersService(presenceManagementDbContext dataDbContext) 
        {
            ManagementPresenceDbContext = dataDbContext;
        }




        public async Task<IEnumerable<Matters>> GetMattersAsync()
        {
            List<Matters> matters = ManagementPresenceDbContext.Matters.Select(m => new Matters()
            {
                MatterId = m.MatterId,
                MatterName = m.MatterName
            }
            ).ToList();
            return await Task.FromResult(matters);
        }





        public async Task<Matters?> GetMatterIdAsync(int id)
        {
            return await Task.FromResult(ManagementPresenceDbContext.Matters.Where(r => r.MatterId == id).FirstOrDefault());
        }






        public async Task<Matters> CreateMatterAsync(MattersImage MattersImages)
        {
            Matters matter = new Matters();

            if (MattersImages != null)
            {
                matter.MatterName = MattersImages.MatterName;
                ManagementPresenceDbContext.Add(matter);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return matter;
            }

            return matter;
        }





        public async Task<Matters> UpdateMatterAsync(MattersImage MattersImages)
        {
            Matters matter = new Matters();

            if (MattersImages != null)
            {
                matter.MatterId = MattersImages.MatterId;
                matter.MatterName = MattersImages.MatterName;
                ManagementPresenceDbContext.Update(matter);
                await ManagementPresenceDbContext.SaveChangesAsync();
                return matter;
            }

            return matter;
        }






        public async Task<bool> DeleteMatterAsync(int id)
        {
            var matter = await GetMatterIdAsync(id);
            if (matter == null)
                return false;
            ManagementPresenceDbContext.Remove(matter);
            await ManagementPresenceDbContext.SaveChangesAsync();
            return true;
        }

    }






}
