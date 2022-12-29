using BuberBreakfast.Models;

namespace BuberBreakfast.Repositorios.Interface
{
    public interface IBreakfastRepo
    {
        Task<List<BreakfastModel>> GetBreakfasts();
        Task<BreakfastModel> GetByID(int id);
        Task<BreakfastModel> AddBreakfast(BreakfastModel breakfast);
        Task<BreakfastModel> UpdateBreakfast(BreakfastModel breakfast, int id);
        Task<bool> DeleteBreakfast (int id);
    }
}
