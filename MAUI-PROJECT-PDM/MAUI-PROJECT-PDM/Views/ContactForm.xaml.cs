namespace MAUI_PROJECT_PDM.Views;
using MAUI_PROJECT_PDM.Models;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Maui.Controls;

public partial class ContactForm : ContentPage
{
    private User _user;

    public ContactForm(User user)
    {
        InitializeComponent();
        _user = user;
        emailContact.Text = _user.Email;
    }

    private async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        // Retrieve the values entered by the user
        var firstName = firstNameContact.Text;
        var lastName = lastNameContact.Text;
        var email = _user.Email;
        var messageText = messageContact.Text;

        // Contact Object
        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Message = messageText

        };

        // IT DOESN'T WORK YET
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress($"{firstName} {lastName}", email));
        message.To.Add(new MailboxAddress("marvdan753", "marvdan753@gmail.com"));
        message.Subject = $"Contact form: {firstName} {lastName}";

        message.Body = new TextPart("plain")
        {
            Text = $"First Name: {firstName}\nLast Name: {lastName}\nEmail: {email}\n\nMessage:\n{messageText}"
        };

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("marvdan753@gmail.com", "rzpcvukfskevaogh");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            await DisplayAlert("Success", "Your message is sent and will be viewed by one of staff", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to send message: {ex.Message}", "OK");
        }

        
    }
}

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
