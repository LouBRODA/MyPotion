using Blazored.LocalStorage;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MyPotion.Models;
using MyPotion.Services;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace MyPotion.Pages
{
    public partial class Alambic
    {
        private Ingredient[] ingredients;

        private string test;

        [Inject]
        public IStringLocalizer<Alambic> Localizer { get; set; }

        /*private Potion MelangePotion = new Potion
        {
            Name = "Potion1",
            Image = "Potion1.png",
            Color = "red",
            Effect = "splash",
            Ingredients = { "Melon Doré" },
        };*/

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //speciaux.add(Ingredient.name="Redstone");

        protected override async Task OnInitializedAsync()
        {
            ingredients = await Http.GetFromJsonAsync<Ingredient[]>($"{NavigationManager.BaseUri}data.json");
        }

        protected void onClickAction()
        {
            test = "test";
        }
    }
}
