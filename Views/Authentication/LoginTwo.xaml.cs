using System.Net.Http.Json;
//using Android.App.Job;
using GeneralMAUI.Models;
using GeneralMAUI.Services;
using GeneralMAUI.Services.Interfaces;

namespace GeneralMAUI.Views.Authentication;


public partial class LoginTwo : ContentPage
{
    private readonly IAuthService _authService;
    private readonly DatabaseService _dbService;
    public LoginTwo(IAuthService authService, DatabaseService dbService)
	{
		InitializeComponent();
        // _httpClient.BaseAddress = new Uri("https://localhost:7203"); // Use actual IP on device
        _authService = authService;
        _dbService = dbService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var login = new UserLogin
        {
            Username = UsernameEntry.Text,
            Password = PasswordEntry.Text
        };

        try
        {
            var result = await _authService.LoginAsync(login);
            MessageLabel.Text = $"Welcome! Token: {result.Token}";
            MessageLabel.TextColor = Colors.Green;
        }
        catch (Exception ex)
        {
            MessageLabel.Text = ex.Message;
            MessageLabel.TextColor = Colors.Red;
        }

        //try
        //{
        //    var response = await _httpClient.PostAsJsonAsync("/api/auth/login", login);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        //        MessageLabel.TextColor = Colors.Green;
        //        MessageLabel.Text = result?.Message;
        //    }
        //    else
        //    {
        //        var error = await response.Content.ReadFromJsonAsync<LoginResponse>();
        //        MessageLabel.TextColor = Colors.Red;
        //        MessageLabel.Text = error?.Message;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    MessageLabel.TextColor = Colors.Red;
        //    MessageLabel.Text = $"Error: {ex.Message}";
        //}

    }



    //
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _dbService.InitAsync();
        await LoadUsers();
    }

    private async Task LoadUsers()
    {
        var users = await _dbService.GetUsersAsync();
        UsersListView.ItemsSource = users;
    }

    private async void OnAddUserClicked(object sender, EventArgs e)
    {
        await _dbService.AddUserAsync(new CustomUser { Name = $"User {DateTime.Now.Ticks % 10000}" });
        await LoadUsers();
    }
}



