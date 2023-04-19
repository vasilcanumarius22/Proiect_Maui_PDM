using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

public partial class FoodDetail : ContentPage
{
	Food food;
	public FoodDetail(Food food)
	{
		InitializeComponent();
		this.food = food;

		labelTitle.Text = food.Title;
		// todo
	}

    private void AddFoodToDb(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}