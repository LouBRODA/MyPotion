using MyPotion.Models;

namespace MyPotion.Factories
{
    public static class IngredientFactory
    {
        public static IngredientModel ToModel(Ingredient ingredient, byte[] imageContent)
        {
            return new IngredientModel
            {
                Name = ingredient.Name,
                Image = ingredient.Image,
                Effect = ingredient.Effect,
            };
        }

        public static Ingredient Create(IngredientModel model)
        {
            return new Ingredient
            {
                Name = model.Name,
                Image = model.Image,
                Effect = model.Effect,
            };
        }

        public static void Update(Ingredient ingredient, IngredientModel model)
        {
            ingredient.Name = model.Name;
            ingredient.Image = model.Image;
            ingredient.Effect = model.Effect;
        }
    }
}
