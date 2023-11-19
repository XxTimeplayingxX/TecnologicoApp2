using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TecnologicoApp.MODELS;
using CommunityToolkit.Maui.Alerts;
using System.Text.RegularExpressions;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"
        public UsuarioRegistro Usuario { get; set; }
        public Command LoginCommand { get; set; }
        public MainPageViewModel() 
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
        }
        #endregion
        #region Loginn
        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email))
            {
                await ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }
            await Shell.Current.GoToAsync(nameof(WelcomeLogin));
        }
        #endregion
        
        private bool IsAValidEmail(string email)
        {
            return Regex.IsMatch(email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase);
        }
        private async Task ShowToastAsync(string message)
        {
            var toast = Toast.Make(message);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(4));
            await toast.Show(cts.Token);
        }
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
