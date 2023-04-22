using MAUI_PROJECT_PDM.Models;
using MAUI_PROJECT_PDM.Views;
using System.Net.Http.Json;
using System.Windows.Input;

namespace MAUI_PROJECT_PDM;

public partial class MainPage : ContentPage
{
    private const string URL_FOODS = "https://raw.githubusercontent.com/Alexsandrux/Json-File-Examples/main/foods-json.json";
    private User user;
    private List<Food> foods = new List<Food>();
    public MainPage(User userDB)
	{
		InitializeComponent();
        user = userDB;

        getFoods();


	}

    private async void getFoods()
    {
        using (HttpClient client = new HttpClient())
        {

            this.foods = await client.GetFromJsonAsync<List<Food>>(URL_FOODS);

            listViewFoods.ItemsSource = this.foods;

        }
    }
    private void Toolbar_Profile_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage(user));
    }

    private void Toolbar_LogOut_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Login());
    }


    public void OpenFoodDetail(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FoodDetail(listViewFoods.SelectedItem as Food, user));
    }

    private async void ToolbarItem_MyFoods_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MyFoods(user));
    }
}

