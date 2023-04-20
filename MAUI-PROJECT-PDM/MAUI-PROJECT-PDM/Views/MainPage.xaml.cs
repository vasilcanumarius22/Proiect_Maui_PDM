using MAUI_PROJECT_PDM.Models;
using MAUI_PROJECT_PDM.Views;
using System.Windows.Input;

namespace MAUI_PROJECT_PDM;

public partial class MainPage : ContentPage
{
    private User user;
	public MainPage(User userDB)
	{
		InitializeComponent();
        user = userDB;
        listViewFoods.ItemsSource = MockFoods.foods;
	}
    // TODO: De infrumusetat cum arata un element din lista
    // TODO: De citit elemente din JSON + de realizat json-ul

    // TODO: De adaugat restul paginilor
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
        //Handle the button click logic here
        Navigation.PushAsync(new FoodDetail(listViewFoods.SelectedItem as Food));
    }

}

