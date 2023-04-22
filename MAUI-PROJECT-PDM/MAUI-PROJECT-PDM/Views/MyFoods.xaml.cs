using MAUI_PROJECT_PDM.Models;
using static SQLite.SQLite3;

namespace MAUI_PROJECT_PDM.Views;

public partial class MyFoods : ContentPage
{
	List<Food> foods;
    User user;
    DaoFood dao;
    DateTime datePicked;
	public MyFoods(User user)
	{
		InitializeComponent();

        this.user = user;

        datePicked = DateTime.Now;
	}

    protected async override void OnAppearing()
    {
        await getFoods();
    }

    private  async Task<int> getFoods()
    {
        if (dao == null)
            dao = new DaoFood();

        foods = await dao.GetAllByDateAndUser(datePicked, user);

        listViewMyFoods.ItemsSource = null;


        listViewMyFoods.ItemsSource = foods;

        return 0;
    }
    

    private async void RemoveFood(object sender, ItemTappedEventArgs e)
    {
        bool deleteCheck = await DisplayAlert("Do you want to delete the item?", "You will delete the item in the list. Are you sure?", "Yes!", "No!");

        if (!deleteCheck) return; 

        if (dao == null)
            dao = new DaoFood();


        Food foodToDelete = listViewMyFoods.SelectedItem as Food;

        int result = await dao.Remove(foodToDelete) ;

        if (result > 0)
        {
            await DisplayAlert("Success", "The food was deleted from your list.", "OK");

            foods.Remove(foodToDelete);

            listViewMyFoods.ItemsSource = null;


            listViewMyFoods.ItemsSource = foods;
        }
        else
        {
            await DisplayAlert("Error", "Error when deleting the food.. try again.", "OK");
        }
    }

    private async void DatePicker_Food_DateSelected(object sender, DateChangedEventArgs e)
    {
        datePicked = DatePicker_Food.Date;

       await getFoods();
    }
}