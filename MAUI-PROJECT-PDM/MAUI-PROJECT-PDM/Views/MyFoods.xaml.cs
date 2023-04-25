using MAUI_PROJECT_PDM.Models;
using static SQLite.SQLite3;

namespace MAUI_PROJECT_PDM.Views;

// Definition of the MyFoods class as a partial class that inherits from ContentPage
public partial class MyFoods : ContentPage
{
    // Declare class-level variables
    List<Food> foods;
    User user;
    DaoFood dao;
    DateTime datePicked;

    // Constructor for the MyFoods class
    public MyFoods(User user)
    {
        InitializeComponent();

        // Assign the provided User object to the class-level user variable
        this.user = user;

        // Initialize the datePicked variable with the current date
        datePicked = DateTime.Now;
    }

    // Override the OnAppearing method to load data when the page appears
    protected async override void OnAppearing()
    {
        await getFoods();
    }

    // Async method to get food items for the current user and date
    private async Task<int> getFoods()
    {
        // Initialize DaoFood if it hasn't been instantiated yet
        if (dao == null)
            dao = new DaoFood();

        // Retrieve the list of foods based on the selected date and user
        foods = await dao.GetAllByDateAndUser(datePicked, user);

        // Refresh the page content
        refreshPage();

        // Return 0 to match the return type of the method
        return 0;
    }

    // Async method to remove a food item from the list
    private async void RemoveFood(object sender, ItemTappedEventArgs e)
    {
        // Prompt the user to confirm the deletion of the selected food item
        bool deleteCheck = await DisplayAlert("Do you want to delete the item?", "You will delete the item in the list. Are you sure?", "Yes!", "No!");

        // Exit the method if the user chooses not to delete the item
        if (!deleteCheck) return;

        // Initialize DaoFood if it hasn't been instantiated yet
        if (dao == null)
            dao = new DaoFood();

        // Get the selected food item from the ListView
        Food foodToDelete = listViewMyFoods.SelectedItem as Food;

        // Attempt to delete the selected food item from the database
        int result = await dao.Remove(foodToDelete);

        // If the deletion was successful, display a success message and update the page content
        if (result > 0)
        {
            await DisplayAlert("Success", "The food was deleted from your list.", "OK");

            foods.Remove(foodToDelete);


            refreshPage();

        }
        else
        {
            // If the deletion was unsuccessful, display an error message
            await DisplayAlert("Error", "Error when deleting the food.. try again.", "OK");
        }
    }

    private async void DatePicker_Food_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Async method to update the displayed food items when the date is changed
        datePicked = DatePicker_Food.Date;

        // Refresh the list of foods based on the new date
        await getFoods();
    }

    // Method to refresh the page content
    private void refreshPage()
    {
        // Reset the ItemsSource for the ListView to force a UI update
        listViewMyFoods.ItemsSource = null;
        listViewMyFoods.ItemsSource = foods;

        // Calculate the total sum of calories from the foods list
        float totalSum = 0;
        foreach (var item in foods)
        {
            totalSum += item.Calories;
        }

        // Update the label to display the total sum of calories
        label_total_calories.Text = "Total Calories: " + totalSum.ToString();
    }
}