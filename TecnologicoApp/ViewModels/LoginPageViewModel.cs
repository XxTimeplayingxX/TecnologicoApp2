using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.MODELS;
using TecnologicoApp.Services;
using TecnologicoApp.Services.Interfaces;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly ISignUpSignInService signUpSignInService;
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        #endregion

        public LoginPageViewModel(ISignUpSignInService signUpSignInService)
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
            RegisterCommand = new Command(GotoSignupPageAsync);
            //OtraPagina();
            this.signUpSignInService = signUpSignInService;
        }

        #region "Logic"
        private async void SignUpAsync()
        {
            var result = await signUpSignInService.SignUpAsync(Usuario);
            if(result == false)
            {
                await Util.ShowToastAsync("No se registro el usuario");
                return;
            }
            await Util.ShowToastAsync($"Usuario {Usuario.Email} registrado exitosamente");
        }
        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || Util.IsAValidEmail(Usuario.Email.ToLower()))
            {
                await Util.ShowToastAsync("Ingrese un Email Válido");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese una Contraseña Válida");
                return;
            }
            var loginData = GetLoginData();

            if(loginData != null && !loginData.Any())
            {
                await Util.ShowToastAsync("Configure Usuarios");
                return;
            }
            var loginDataEmail = loginData.FirstOrDefault(x => x.Key == Usuario.Email);
            
            if(loginDataEmail.Equals(default(KeyValuePair<string, string>)))
            {
                await Util.ShowToastAsync($"El correo {Usuario.Email} no existe");
                return;
            }
            if(loginDataEmail.Value != Usuario.Password)
            {
                await Util.ShowToastAsync($"Contraseña Incorrecta");
                return;
            }
            Settings.IsAuthenticated = true;
            Settings.Email = Usuario.Email;
            await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
        }
        
        private async void GotoSignupPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(SignupPage));
        }
        public void OtraPagina()
        {
            string mensaje = $"Bienvenido {Usuario.Email}";
        }

       
        private List<KeyValuePair<string, string>> GetLoginData()
        {
            var result = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("daviquesan@gmail.com", "123456789"),
                new KeyValuePair<string, string>("dOlivo@gmail.com", "soyFalconez"),
                new KeyValuePair<string, string>("eFalconez@gmail.com", "soyOlivo"),
                new KeyValuePair<string, string>(Settings.RegistroEmail, Settings.RegistroPassword)
            };
            return result;

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}