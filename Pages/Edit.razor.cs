using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyPotion.Models;
using MyPotion.Services;

namespace MyPotion.Pages
{
    public partial class Edit
    {
        [Parameter]
        public int Id { get; set; }

        /// <summary>
        /// The current item model
        /// </summary>
        private IngredientModel ingredientModel = new();

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var ingredient = await DataService.GetById(Id);

            var fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/default.png");

            // Set the model with the item
            ingredientModel = new IngredientModel
            {
                Id = ingredientModel.Id,
                Name = ingredientModel.Name,
                Image = ingredientModel.Image,
                Effect = ingredientModel.Effect,
                Special = ingredientModel.Special,
            };
        }

        private async void HandleValidSubmit()
        {
            await DataService.Update(Id, ingredientModel);

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
