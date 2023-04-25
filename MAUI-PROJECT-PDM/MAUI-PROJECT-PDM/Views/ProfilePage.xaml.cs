using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

// Definition of the ProfilePage class as a partial class that inherits from ContentPage
public partial class ProfilePage : ContentPage
{
    // Declare class-level variables
    private bool isEditing = false;
    private User userDB;

    // Constructor for the ProfilePage class
    public ProfilePage(User user)
	{
		InitializeComponent();

        // Set the BindingContext to the provided User object
        BindingContext = user;

        // Assign the provided User object to the class-level userDB variable
        userDB = user;
	}

    // Event handler for the Edit button click event
    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        // Check if the user is in editing mode
        if (isEditing)
        {
            // Update the user information
            var daoUser = new DaoUser();

            // Update the user properties with the new values from the input fields
            User userToUpdate = await daoUser.GetUserById(userDB.Id);
            userToUpdate.FirstName = firstNameProfile.Text;
            userToUpdate.LastName = lastNameProfile.Text;
            userToUpdate.Email = emailUserProfile.Text;
            userToUpdate.BirthDate = birthdateProfile.Date;
            userToUpdate.Password = passwordEntryProfile.Text;

            // Attempt to update the user record in the database
            var result = await daoUser.Update(userToUpdate);

            // Check if the update was successful
            if (result > 0)
            {
                // Display a success alert and update the UI to non-editing mode
                await DisplayAlert("Success", "Record successfully updated", "OK");
                //await Navigation.PushAsync(new ProfilePage(user));

                firstNameProfile.IsEnabled = false;
                lastNameProfile.IsEnabled = false;
                emailUserProfile.IsEnabled = false;
                birthdateProfile.IsEnabled = false;
                buttonProfitEdit.Text = "Edit";
            }
            else
            {
                // Display an error alert if the update fails
                await DisplayAlert("Error", "Updated failed", "OK");
            }
        }
        else
        {
            // Enable editing for the input fields and update the button text
            firstNameProfile.IsEnabled = true;
            lastNameProfile.IsEnabled = true;
            emailUserProfile.IsEnabled = true;
            birthdateProfile.IsEnabled = true;
            buttonProfitEdit.Text = "Update";
        }

        // Toggle the isEditing variable
        isEditing = !isEditing;
    }
}