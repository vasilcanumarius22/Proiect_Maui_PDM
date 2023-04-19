using MAUI_PROJECT_PDM.Models;
using MAUI_PROJECT_PDM.Views;
using System.Windows.Input;

namespace MAUI_PROJECT_PDM;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        listViewFoods.ItemsSource = MockFoods.foods;
	}
    // TODO: De infrumusetat cum arata un element din lista
    // TODO: De citit elemente din JSON + de realizat json-ul

    // TODO: De adaugat restul paginilor
    private void Toolbar_Buton1_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Page());
    }

    private void Toolbar_Buton2_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Page());
    }


    public void OpenFoodDetail(object sender, EventArgs e)
    {
        //Handle the button click logic here
        Navigation.PushAsync(new FoodDetail(listViewFoods.SelectedItem as Food));
    }

}

