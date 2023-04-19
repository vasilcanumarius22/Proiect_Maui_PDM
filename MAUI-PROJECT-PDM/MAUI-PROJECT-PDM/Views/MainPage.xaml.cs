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

}

