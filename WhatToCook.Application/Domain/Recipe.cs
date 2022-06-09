namespace WhatToCook.Application.Domain
{
    public class Recipe
    {
        public Recipe(string name, string preparation, List<Ingredient> ingredients)
        {
            Name = name;
            Preparation = preparation;
            Ingredients = ingredients;
        }

        public string Name { get; }
        public string Preparation { get; }
        public List<Ingredient> Ingredients { get; } = new();
    }
}
