using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using MyPotion.Models;

namespace MyPotion.Services
{
    public class DataLocalService : IDataService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataLocalService(
            ILocalStorageService localStorage,
            HttpClient http,
            IWebHostEnvironment webHostEnvironment,
            NavigationManager navigationManager)
        {
            _localStorage = localStorage;
            _http = http;
            _webHostEnvironment = webHostEnvironment;
            _navigationManager = navigationManager;
        }

        public async Task Add(IngredientModel model)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<Ingredient>>("data");

            // Add the item to the current data
            currentData.Add(new Ingredient
            {
                Id = model.Id,
                Name = model.Name,
                Image = model.Image,
                Effect = model.Effect,
            });

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }

        public async Task<int> Count()
        {
            return (await _localStorage.GetItemAsync<Ingredient[]>("data")).Length;
        }

        public async Task<List<Ingredient>> List(int currentPage, int pageSize)
        {
            // Load data from the local storage
            var currentData = await _localStorage.GetItemAsync<Ingredient[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data
                var originalData = await _http.GetFromJsonAsync<Ingredient[]>($"{_navigationManager.BaseUri}data.json");
                await _localStorage.SetItemAsync("data", originalData);
            }

            return (await _localStorage.GetItemAsync<Ingredient[]>("data")).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<Ingredient> GetById(int id)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<Ingredient>>("data");

            // Get the item int the list
            var ingredient = currentData.FirstOrDefault(w => w.Id == id);

            // Check if item exist
            if (ingredient == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return ingredient;
        }

        public async Task Update(int id, IngredientModel model)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<Ingredient>>("data");

            // Get the item int the list
            var ingredient = currentData.FirstOrDefault(w => w.Id == id);

            // Check if item exist
            if (ingredient == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            // Modify the content of the item
            ingredient.Id = model.Id;
            ingredient.Name = model.Name;
            ingredient.Image = model.Image;
            ingredient.Effect= model.Effect;

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }

        public async Task Delete(int id)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<Ingredient>>("data");

            // Get the item int the list
            var ingredient = currentData.FirstOrDefault(w => w.Id == id);

            // Delete item in
            currentData.Remove(ingredient);

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }
    }
}
