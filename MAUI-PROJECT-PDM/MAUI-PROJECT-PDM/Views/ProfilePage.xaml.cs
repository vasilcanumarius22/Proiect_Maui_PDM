using MAUI_PROJECT_PDM.Models;

namespace MAUI_PROJECT_PDM.Views;

public partial class ProfilePage : ContentPage
{
    private bool isEditing = false;
    private User userDB;
	public ProfilePage(User user)
	{
		InitializeComponent();
		BindingContext = user;
        userDB = user;
	}

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        if (isEditing)
        {
            //update user 
            var daoUser = new DaoUser();

            User userToUpdate = await daoUser.GetUserById(userDB.Id);
            userToUpdate.FirstName = firstNameProfile.Text;
            userToUpdate.LastName = lastNameProfile.Text;
            userToUpdate.Email = emailUserProfile.Text;
            userToUpdate.BirthDate = birthdateProfile.Date;
            userToUpdate.Password = passwordEntryProfile.Text;

            var result= await daoUser.Update(userToUpdate);

            if (result > 0)
            {
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
                await DisplayAlert("Error", "Updated failed", "OK");
            }
        }
        else
        {
            firstNameProfile.IsEnabled = true;
            lastNameProfile.IsEnabled = true;
            emailUserProfile.IsEnabled = true;
            birthdateProfile.IsEnabled = true;
            buttonProfitEdit.Text = "Update";
        }

        isEditing = !isEditing;
    }
}