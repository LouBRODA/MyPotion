using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using MyPotion.Modals;
using MyPotion.Models;
using MyPotion.Services;

namespace MyPotion.Pages
{
    public partial class Ressources
    {

        private Ingredient[] ingredients;

        private int totalIngredients;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Do not treat this action if is not the first render
            if (!firstRender)
            {
                return;
            }

            var currentData = await LocalStorage.GetItemAsync<Ingredient[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                var originalData = Http.GetFromJsonAsync<Ingredient[]>($"{NavigationManager.BaseUri}data.json").Result;
                await LocalStorage.SetItemAsync("data", originalData);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            ingredients = await Http.GetFromJsonAsync<Ingredient[]>($"{NavigationManager.BaseUri}data.json");
        }

        private async void OnDelete(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(Ingredient.Id), id);

            var modal = Modal.Show<DeleteConfirmation>("Delete Confirmation", parameters);
            var result = await modal.Result;

            if (result.Cancelled)
            {
                return;
            }

            await DataService.Delete(id);

            // Reload the page
            NavigationManager.NavigateTo("ressources", true);
        }
    }
}
