using MyPotion.Models;
using MyPotion.Factories;

namespace MyPotion.Services
{
    public class DataApiService : IDataService
    {
        private readonly HttpClient _http;

        public DataApiService(
            HttpClient http)
        {
            _http = http;
        }

        public async Task Add(IngredientModel model)
        {
            // Get the item
            var ingredient = IngredientFactory.Create(model);

            // Save the data
            await _http.PostAsJsonAsync("https://localhost:7234/api/Crafting/", ingredient);
        }

        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/Crafting/count");
        }

        public async Task<List<Ingredient>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<Ingredient>>($"https://localhost:7234/api/Crafting/?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _http.GetFromJsonAsync<Ingredient>($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task Update(int id, IngredientModel model)
        {
            // Get the item
            var ingredient = IngredientFactory.Create(model);

            await _http.PutAsJsonAsync($"https://localhost:7234/api/Crafting/{id}", ingredient);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"https://localhost:7234/api/Crafting/{id}");
        }

        /*public async Task<List<CraftingRecipe>> GetRecipes()
        {
            return await _http.GetFromJsonAsync<List<CraftingRecipe>>("https://localhost:7234/api/Crafting/recipe");
        }*/
    }
}
