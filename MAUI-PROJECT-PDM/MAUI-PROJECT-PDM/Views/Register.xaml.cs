using MAUI_PROJECT_PDM.Models;
using System.Text.RegularExpressions;

namespace MAUI_PROJECT_PDM.Views;

// Definition of the Register class as a partial class that inherits from ContentPage
public partial class Register : ContentPage
{
    // Declaration of Regex instance for validating password strength
    private Regex regex;

    // Constructor for the Register class
    public Register()
    {
        InitializeComponent();

        // regex initialization for password validation with a specified patterns
        regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }

    // Event handler for the register button click event
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Check if any input field is empty
        if (string.IsNullOrEmpty(firstNameEntry.Text)
            || string.IsNullOrEmpty(lastNameEntry.Text)
            || string.IsNullOrEmpty(emailEntry.Text)
            || string.IsNullOrEmpty(passwordEntry.Text)
            || string.IsNullOrEmpty(confirmPasswordEntry.Text))
        {
            // Displays an error alert if fields are empty
            await DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }

        // Checks if the password and confirmation password match
        if (!passwordEntry.Text.Equals(confirmPasswordEntry.Text))
        {
            // Display an error alert if passwords do not match
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        // Checks if the entered email is valid
        if (!emailEntry.Text.Contains("@"))
        {
            // Display an error alert if the email is invalid
            await DisplayAlert("Error", "Invalid Email", "OK");
            return; 
        }

        // Check if the entered password meets the strength requirements (regex requirements)
        if (!regex.IsMatch(passwordEntry.Text) && passwordEntry.Text.Length < 8)
        {
            await DisplayAlert("Error", "password should have at least 8 characters, one capital letter and one number", "OK");
            return;
        }

        // Create a new User instance and populate its properties
        var user = new User
        {
            FirstName = firstNameEntry.Text,
            LastName = lastNameEntry.Text,
            Email = emailEntry.Text,
            BirthDate = birthdatePicker.Date,
            Password = passwordEntry.Text
        };

        // Create a new instance of DaoUser
        var daoUser = new DaoUser();

        // Insert the new user into the database
        var result = await daoUser.Insert(user);

        // Check if the user registration is successful
        if (result > 0)
        {
            // Display a success alert and navigate to the main page
            await DisplayAlert("Success", "Registration successful.", "OK");
            //await Navigation.PushAsync(new ProfilePage(user));
            await Navigation.PushAsync(new MainPage(user));
        }
        else
        {
            // Display an error alert if registration fails
            await DisplayAlert("Error", "Registration failed.", "OK");
        }
    }

    // Event handler for the show/hide password button click event
    private void Button_ShowPass_Clicked(object sender, EventArgs e)
    {
        // Toggle the password visibility for both password input fields
        passwordEntry.IsPassword = !passwordEntry.IsPassword;
        confirmPasswordEntry.IsPassword =!confirmPasswordEntry.IsPassword;

        // Update the button text based on the password visibility
        if (passwordEntry.IsPassword && confirmPasswordEntry.IsPassword)
        {
            ((Button)sender).Text = "Show Password";
        }
        else
        {
            ((Button)sender).Text = "Hide Password";
        }
    }

    // Event handler for the register input field completion event
    private void register_Completed(object sender, EventArgs e)
    {
        // Invoke the register button click event handler
        OnRegisterButtonClicked(sender, e);
    }
}