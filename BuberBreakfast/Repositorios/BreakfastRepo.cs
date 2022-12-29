using Microsoft.EntityFrameworkCore;
using BuberBreakfast.Models;
using BuberBreakfast.Repositorios;
using BuberBreakfast.Repositorios.Interface;

namespace BuberBreakfast.Repositorios
{
    public class BreakfastRepo : IBreakfastRepo
    {
        private readonly BreakfastContext _breakfastContext;
        public BreakfastRepo(BreakfastContext breakfastContext)
        {
            _breakfastContext = breakfastContext;
        }

        public async Task<BreakfastModel> AddBreakfast(BreakfastModel breakfast)
        {
            await _breakfastContext.Breakfasts.AddAsync(breakfast);
            await _breakfastContext.SaveChangesAsync();

            return breakfast;
        }

        public async Task<bool> DeleteBreakfast(int id)
        {
            BreakfastModel breakfastByID = await GetByID(id);

            if(breakfastByID == null)
            {
                throw new Exception("The specified ID does not exist in the database");
            }

            _breakfastContext.Breakfasts.Remove(breakfastByID);
            await _breakfastContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<BreakfastModel>> GetBreakfasts()
        {
            return await _breakfastContext.Breakfasts.ToListAsync();
        }

        public async Task<BreakfastModel> GetByID(int id)
        {
            return await _breakfastContext.Breakfasts.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<BreakfastModel> UpdateBreakfast(BreakfastModel breakfast, int id)
        {
            BreakfastModel breakfastByID = await GetByID(id);

            if (breakfastByID == null)
            {
                throw new Exception("The specified ID does not exist in the database");
            }

            breakfastByID.Name = breakfast.Name;
            breakfastByID.Description = breakfast.Description;

            _breakfastContext.Breakfasts.Update(breakfastByID);
            await _breakfastContext.SaveChangesAsync();

            return breakfastByID;
        }
    }
}
