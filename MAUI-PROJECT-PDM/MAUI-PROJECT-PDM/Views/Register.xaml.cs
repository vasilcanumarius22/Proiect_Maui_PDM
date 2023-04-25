using MAUI_PROJECT_PDM.Models;
using System.Text.RegularExpressions;

namespace MAUI_PROJECT_PDM.Views;

public partial class Register : ContentPage
{
    private Regex regex;
    public Register()
    {
        InitializeComponent();
        regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(firstNameEntry.Text)
            || string.IsNullOrEmpty(lastNameEntry.Text)
            || string.IsNullOrEmpty(emailEntry.Text)
            || string.IsNullOrEmpty(passwordEntry.Text)
            || string.IsNullOrEmpty(confirmPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please fill all fields.", "OK");
            return;
        }
        if (!passwordEntry.Text.Equals(confirmPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        if (!emailEntry.Text.Contains("@"))
        {
            await DisplayAlert("Error", "Invalid Email", "OK");
            return; 
        }

        if (!regex.IsMatch(passwordEntry.Text) && passwordEntry.Text.Length < 8)
        {
            await DisplayAlert("Error", "password should have at least 8 characters, one capital letter and one number", "OK");
            return;
        }

        var user = new User
        {
            FirstName = firstNameEntry.Text,
            LastName = lastNameEntry.Text,
            Email = emailEntry.Text,
            BirthDate = birthdatePicker.Date,
            Password = passwordEntry.Text
        };

        var daoUser = new DaoUser();
        var result = await daoUser.Insert(user);

        if (result > 0)
        {
            await DisplayAlert("Success", "Registration successful.", "OK");
            //await Navigation.PushAsync(new ProfilePage(user));
            await Navigation.PushAsync(new MainPage(user));
        }
        else
        {
            await DisplayAlert("Error", "Registration failed.", "OK");
        }
    }

    private void Button_ShowPass_Clicked(object sender, EventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;
        confirmPasswordEntry.IsPassword =!confirmPasswordEntry.IsPassword;

        if (passwordEntry.IsPassword && confirmPasswordEntry.IsPassword)
        {
            ((Button)sender).Text = "Show Password";
        }
        else
        {
            ((Button)sender).Text = "Hide Password";
        }
    }

    private void register_Completed(object sender, EventArgs e)
    {
        OnRegisterButtonClicked(sender, e);
    }
}