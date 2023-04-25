using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

// Definition of the Login class as a partial class that inherits from ContentPage
public partial class Login : ContentPage
{
    // Constructor for the Login class
    public Login()
    {
        InitializeComponent();
    }

    // Event handler for the login button click event
    private async void LoginButtonClicked(object sender, EventArgs e)
    {
        // Creates a new instance of DaoUser
        var daoUser = new DaoUser();

        // Checks if the email and password fields are empty or not
        if (string.IsNullOrEmpty(emailLogIn.Text)
           || string.IsNullOrEmpty(passwordLogIn.Text))
        {
            // Display an alert if fields are empty
            await DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }
        else
        {
            // Get the email and password from the input fields
            var email = emailLogIn.Text;
            var password = passwordLogIn.Text;

            // Create a new instance of DaoUser
            var dao = new DaoUser();

            // Authenticate the user with the entered email and password
            var result = await daoUser.AuthenticateUser(email, password);

            // Check if the user is authenticated
            if (result != null)
            {
                // Display a success alert and navigate to the main page
                await DisplayAlert("Success", "You are successfully logged in", "OK");
                await Navigation.PushAsync(new MainPage(result));
            }
            else
            {
                // Display an error alert if authentication fails
                await DisplayAlert("Error", "Login failed.", "OK");
            }
        }
    }

    // Event handler for the sign-up button click event
    private async void SignUpButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private void login_Completed(object sender, EventArgs e)
    {
        // Invoke the login button click event handler
        LoginButtonClicked(sender, e);
    }

    // Event handler for the show/hide password button click event
    private void Button_ShowPass_Clicked(object sender, EventArgs e)
    {
        // Toggle the password visibility in the password input field
        passwordLogIn.IsPassword = !passwordLogIn.IsPassword;

        // Update the button text based on the password visibility
        if (passwordLogIn.IsPassword)
        {
            ((Button)sender).Text = "Show Password";
        }
        else
        {
            ((Button)sender).Text = "Hide Password";
        }
    }
}