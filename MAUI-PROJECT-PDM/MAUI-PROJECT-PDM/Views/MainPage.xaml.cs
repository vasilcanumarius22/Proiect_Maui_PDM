using MAUI_PROJECT_PDM.Models;
using MAUI_PROJECT_PDM.Views;
using System.Net.Http.Json;
using System.Windows.Input;

namespace MAUI_PROJECT_PDM;

// Definition of the MainPage class as a partial class that inherits from ContentPage
public partial class MainPage : ContentPage
{
    // URL for the JSON file containing food data
    private const string URL_FOODS = "https://raw.githubusercontent.com/Alexsandrux/Json-File-Examples/main/foods-json.json";

    // Instance variables to store the current user and a list of food items
    private User user;
    private List<Food> foods = new List<Food>();

    // Constructor for the MainPage class, accepting a User object
    public MainPage(User userDB)
	{
		InitializeComponent();

        // Assign the passed User object to the local user variable
        user = userDB;

        // Call the method to fetch the food items
        getFoods();


	}

    // Method to fetch food items from the URL_FOODS JSON file
    private async void getFoods()
    {
        using (HttpClient client = new HttpClient())
        {
            // Retrieve the food items from the URL and assign them to the local foods list
            this.foods = await client.GetFromJsonAsync<List<Food>>(URL_FOODS);

            // Set the ItemsSource of the listViewFoods to display the fetched food items
            listViewFoods.ItemsSource = this.foods;

        }
    }

    // Event handler for the toolbar profile button click event
    private void Toolbar_Profile_Clicked(object sender, EventArgs e)
    {
        // Navigate to the ProfilePage, passing the current user
        Navigation.PushAsync(new ProfilePage(user));
    }

    // Event handler for the toolbar logout button click event
    private void Toolbar_LogOut_Clicked(object sender, EventArgs e)
    {
        // Navigate back to the Login page
        Navigation.PushAsync(new Login());
    }

    // Event handler for the food item selection event
    public void OpenFoodDetail(object sender, EventArgs e)
    {
        // Navigate to the FoodDetail page, passing the selected food item and the current user
        Navigation.PushAsync(new FoodDetail(listViewFoods.SelectedItem as Food, user));
    }

    // Event handler for the toolbar my foods button click event
    private async void ToolbarItem_MyFoods_Clicked(object sender, EventArgs e)
    {
        // Navigate to the MyFoods page, passing the current user
        await Navigation.PushAsync(new MyFoods(user));
    }

    // Event handler for the toolbar contact button click event
    private async void Toolbar_Contact_Clicked(object sender, EventArgs e)
    {
        // Navigate to the ContactForm page, passing the current user
        await Navigation.PushAsync(new ContactForm(user));
    }

    // Event handler for the toolbar about us button click event
    private async void ToolbarItem_AboutUs_Clicked(object sender, EventArgs e)
    {
        // Navigate to the AboutUs page
        await Navigation.PushAsync(new AboutUs());
    }
}

