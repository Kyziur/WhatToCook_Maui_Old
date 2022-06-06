
namespace WhatToCook.SharedUI.Pages.Recipe
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly CreatedAt { get; set; } = DateOnly.MinValue;
        public bool IsInFavourites { get; set; }
    }
}
