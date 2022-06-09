namespace WhatToCook.Application.Domain
{
    public class Ingredient
    {
        public Ingredient(uint amount, string unit, string name)
        {
            Amount = amount;
            if (unit.IsEmpty())
            {
                throw new ArgumentException("Ingredient unit cannot be empty", nameof(unit));
            }
            Unit = unit.ToLower();

            if (name.IsEmpty())
            {
                throw new ArgumentException("Ingredient name cannot be empty", nameof(name));
            }
            Name = name.Capitalize();
        }

        public uint Amount { get; }
        public string Unit { get; }
        public string Name { get; }
    }
}