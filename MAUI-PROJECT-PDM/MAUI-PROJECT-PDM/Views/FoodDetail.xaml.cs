using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

public partial class FoodDetail : ContentPage
{
	Food food;
	public FoodDetail(Food food)
	{
		InitializeComponent();
		this.food = food;

		// hello world
	}
}