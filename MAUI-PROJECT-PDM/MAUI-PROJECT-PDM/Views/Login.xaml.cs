using MAUI_PROJECT_PDM.Models;


namespace MAUI_PROJECT_PDM.Views;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    // Marius TODO - Add Enter key event listener for login

    private async void LoginButtonClicked(object sender, EventArgs e)
    {
        var daoUser = new DaoUser();
        if (string.IsNullOrEmpty(emailLogIn.Text)
           || string.IsNullOrEmpty(passwordLogIn.Text))
        {
            await DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        } else
        {
            var email = emailLogIn.Text;
            var password = passwordLogIn.Text;

            var dao = new DaoUser();

            var result = await daoUser.AuthenticateUser(email,password);

            if (result!=null)
            {
                await DisplayAlert("Success", "You are successfully logged in", "OK");
                await Navigation.PushAsync(new MainPage(result));
            }
            else
            {
                await DisplayAlert("Error", "Login failed.", "OK");
            }
        }
    }

    private async void SignUpButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private void login_Completed(object sender, EventArgs e)
    {
        LoginButtonClicked(sender, e);
    }
}