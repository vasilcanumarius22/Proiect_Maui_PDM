using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

// Definition of the FoodDetail class as a partial class that inherits from ContentPage
public partial class FoodDetail : ContentPage
{
    // Declare Food and User objects to store food and user details
    Food food;
    User user;

    // Constructor for the FoodDetail class that accepts Food and User objects
    public FoodDetail(Food food, User user)
    {
        InitializeComponent();

        // Assign the input food and user objects to class variables
        this.food = food;
        this.user = user;

        // Update the UI with food details
        labelTitle.Text = food.Title;
        labelCalories.Text = food.Calories.ToString();
        labelCarbohydrates.Text = food.Carbohydrates.ToString();
        labelFibers.Text = food.Fibers.ToString();
        labelSugars.Text = food.Sugars.ToString();
        labelProteins.Text = food.Proteins.ToString();
        labelFat.Text = food.Fat.ToString();
        labelSaturatedFat.Text = food.SaturatedFat.ToString();
        labelSodium.Text = food.Sodium.ToString();
    }

    // Event handler for adding food to the database
    private async void AddFoodToDb(object sender, EventArgs e)
    {
        // Create a new instance of DaoFood
        var dao = new DaoFood();

        // Insert the food and user details into the database
        var result = await dao.Insert(food, user);

        // Check if the insertion was successful
        if (result > 0)
        {
            // Display a success alert and pop the current page from the navigation stack
            await DisplayAlert("Success", "The food was added to your foods.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            // Display an error alert if insertion fails
            await DisplayAlert("Error", "Error adding the food.. try again.", "OK");
        }
    }
}