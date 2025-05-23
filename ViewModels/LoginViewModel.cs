using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Java.Security;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace GeneralMAUI.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string message;

        [RelayCommand]
       private async Task Login()
        {
            if (Username == "admin" && Password == "admin")
            {

                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
                {
                    Message = "Login successful!";
                    await Shell.Current.GoToAsync("//MainPage");
                   // myButton.Text = "Click Me";
                }
                else
                {
                    Message = "Login successful!";
                    await Shell.Current.GoToAsync("//HomePage");
                }
            }
            else
            {
                Message = "Please enter correct UserName and Passoword!";

            }
        }
    }
}
