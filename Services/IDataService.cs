using MyPotion.Models;

namespace MyPotion.Services
{
    public interface IDataService
    {
        Task Add(IngredientModel model);

        Task<int> Count();

        Task<List<Ingredient>> List(int currentPage, int pageSize);

        Task<Ingredient> GetById(int id);

        Task Update(int id, IngredientModel model);

        Task Delete(int id);

    }
}
