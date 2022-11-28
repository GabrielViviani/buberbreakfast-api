using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreatedBreakfast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);
}