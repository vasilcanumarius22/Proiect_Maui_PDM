using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

public partial class FoodDetail : ContentPage
{
    Food food;
    User user;
    public FoodDetail(Food food, User user)
    {
        InitializeComponent();
        this.food = food;
        this.user = user;

        labelTitle.Text = food.Title;
        labelCalories.Text = food.Calories.ToString();
        labelCarbohydrates.Text = food.Carbohydrates.ToString();
        labelFibers.Text = food.Fibers.ToString();
        labelSugars.Text = food.Sugars.ToString();
        labelProteins.Text = food.Proteins.ToString();
        labelFat.Text = food.Fat.ToString();
        labelSaturatedFat.Text = food.SaturatedFat.ToString();
        labelSodium.Text = food.Sodium.ToString();
        // todo page contents
    }

    private async void AddFoodToDb(object sender, EventArgs e)
    {
        var dao = new DaoFood();
        var result = await dao.Insert(food, user);

        if (result > 0)
        {
            await DisplayAlert("Success", "The food was added to your foods.", "OK");

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Error adding the food.. try again.", "OK");
        }


    }
}