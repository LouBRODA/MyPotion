using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MyPotion.Models;
using MyPotion.Services;

namespace MyPotion.Pages
{
    public partial class Add
    {

        private IngredientModel ingredientModel = new();

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async void HandleValidSubmit()
        {
            await DataService.Add(ingredientModel);

            NavigationManager.NavigateTo("ressources");
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                ingredientModel.Image = memoryStream.ToString();
            }
        }
    }
}
