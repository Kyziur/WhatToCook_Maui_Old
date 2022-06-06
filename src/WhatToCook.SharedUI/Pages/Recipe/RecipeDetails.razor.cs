namespace WhatToCook.SharedUI.Pages.Recipe;

public class Ingredient
{
    public string Name { get; set; }
    public int Amount { get; set; }
    public string Unit { get; set; }
}

public class RecipeDetailsData
{
    private readonly IStringLocalizer _stringLocalizer;

    public RecipeDetailsData(IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    public Guid? Id { get; set; }
    public string Name { get; set; } = "";
    public int TimeNeededToPrepare { get; set; }
    public string Preparation { get; set; } = "";
    public List<Ingredient> Ingredients { get; set; } = new();

    public string GetLabelForPreparationTime(int time)
        => time switch
        {
            > 0 and < 15 => _stringLocalizer["shortPreparationTime"],
            > 15 and < 45 => _stringLocalizer["mediumPreparationTime"],
            > 45 => _stringLocalizer["longPreparationTime"],
            _ => _stringLocalizer["inputValue"]
        };

    public void UpdatePreparationTime(ChangeEventArgs args)
    {
        TimeNeededToPrepare = int.TryParse(args.Value?.ToString(), out var value) ? value : 0;
    }
}

public partial class RecipeDetails
{
    [Parameter] public Guid Id { get; set; }

    [Inject] private IStringLocalizer<TranslationsPl>? Localizer { get; set; }

    private RecipeDetailsData RecipeForm { get; set; }
    private EditContext? _editContext;

    protected override void OnInitialized()
    {
        RecipeForm = new RecipeDetailsData(Localizer);
        _editContext = new EditContext(RecipeForm);

        // _editContext.OnFieldChanged += (sender, args) =>
        // {
        //     Console.WriteLine($"CHANGED: {JsonSerializer.Serialize(sender)} ||| ${JsonSerializer.Serialize(args)}");
        // };
    }

    private EventCallback AddIngredient()
    {
        RecipeForm.Ingredients.Add(new Ingredient());

        return default;
    }

    private EventCallback RemoveIngredient(int index)
    {
        RecipeForm.Ingredients.RemoveAt(index);

        return default;
    }
}