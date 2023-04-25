namespace MAUI_PROJECT_PDM.Views;
using MAUI_PROJECT_PDM.Models;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Maui.Controls;

// ContactForm class ->  represents a form for submitting contact messages.
public partial class ContactForm : ContentPage
{
    // private User object -> represents the user submitting the contact message.
    private User _user;

    // The constructor for the ContactForm -> initializes the component and sets the user email.
    public ContactForm(User user)
    {
        InitializeComponent();
        _user = user;
        emailContact.Text = _user.Email;
    }

    // Event handler for the submit button click event.
    private async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        // Retrieves the values entered by the user and stores them in local variables.
        var firstName = firstNameContact.Text;
        var lastName = lastNameContact.Text;
        var email = _user.Email;
        var messageText = messageContact.Text;

        // Creates a Contact object with the entered data.
        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Message = messageText

        };

        // Creates a new MimeMessage and sets its properties.
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress($"{contact.FirstName} {contact.LastName}", contact.Email));
        message.To.Add(new MailboxAddress("marvdan753", "marvdan753@gmail.com"));
        message.Subject = $"Contact form: {contact.FirstName} {contact.LastName}";

        message.Body = new TextPart("plain")
        {
            Text = $"First Name: {contact.FirstName}\nLast Name: {contact.LastName}\nEmail: {contact.Email}\n\nMessage:\n{contact.Message}"
        };

        // Creates a new SmtpClient object to send the email.
        using var client = new SmtpClient();

        try
        {
            // Connects to the SMTP server, authenticates, sends the email, and disconnects.
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("marvdan753@gmail.com", "rzpcvukfskevaogh");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            // Displays a success alert to the user.
            await DisplayAlert("Success", "Your message is submited and will be reviewed by our staff soon", "OK");
        }
        catch (Exception ex)
        {
            // Displays an error alert if an exception occurs.
            await DisplayAlert("Error", $"Failed to send message: {ex.Message}", "OK");
        }

        
    }

    private void messageContact_TextChanged(object sender, TextChangedEventArgs e)
    {
        Editor editor = sender as Editor;
        Label maxCharsLabel = this.FindByName<Label>("MaxCharsLabel");

        if (editor.Text.Length >= editor.MaxLength && maxCharsLabel != null)
        {
            maxCharsLabel.IsVisible = true;
        }
        else if (maxCharsLabel != null)
        {
            maxCharsLabel.IsVisible = false;
        }
    }
}

// Contact class -> represents a submitted contact message, with properties for first name, last name, email, and message.
public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
