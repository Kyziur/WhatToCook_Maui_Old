

namespace ApplicationTests.Domain
{
    public class RecipeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_NameIngredientsAndPreparationDescription_When_CreatingRecipe_Then_Succeeds()
        {
            var recipe = new Recipe("Spaghetti", "Take ketchup add pasta and you have true spaghetti", new List<Ingredient>
            {
                new Ingredient(300, "g", "pasta"),
                new Ingredient(150, "ml", "ketchup")
            });

            recipe.Should().NotBeNull();
            recipe.Ingredients.Should().NotBeNull().And.HaveCount(2);
            recipe.Name.Should().NotBeNullOrWhiteSpace();
            recipe.Preparation.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void Given_IngredientsNameAndUnitsWithDifferentCasing_When_CreatingRecipe_Then_RecipeIsCreatedAndNameOfIngredientsIsUnified()
        {
            var expectedRecipeIngredients = new List<Ingredient>
            {
                new Ingredient(300, "G", "Pasta"),
                new Ingredient(150, "mL", "Ketchup"),
                new Ingredient(1, "g", "Spices")
            };
            var recipe = new Recipe("Spaghetti", "Take ketchup add pasta and you have true spaghetti", new List<Ingredient>
            {
                new Ingredient(300, "g", "PasTa"),
                new Ingredient(150, "ml", "ketChup"),
                new Ingredient(1, "g", "spiCes")
            });

            recipe.Should().NotBeNull();
            recipe.Ingredients.Should().BeEquivalentTo(expectedRecipeIngredients);
        }
    }
}