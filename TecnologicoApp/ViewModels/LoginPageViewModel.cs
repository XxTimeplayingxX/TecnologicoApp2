using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.MODELS;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }
        public Command RegisterCommando { get; set; }

        #endregion

        public LoginPageViewModel()
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
            OtraPagina();
        }

        #region "Logic"

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || !IsAValidEmail(Usuario.Email.ToLower()))
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




            //List<string> ListaUsuario = new List<string>
            //{
            //    "daviquesan@gmail.com",
            //    "dolvi123@gmail.com",
            //    "ofalconez1978@gmail.com",
            //    "d1sanchez@gmail.com",
            //    "david@istlcg.com",
            //    "gus@mail.com"
            //};

            //bool estaEnLaLista = ListaUsuario.Contains(Usuario.Email);

            //if (estaEnLaLista)
            //{
            //    

            //}
            //else
            //{
            //    await Util.ShowToastAsync("Correo No Registrado");
            //}



            //Settings.IsAuthenticated = true;


        }
        private async void GotoSignupPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
        }
        public void OtraPagina()
        {
            string mensaje = $"Bienvenido {Usuario.Email}";
        }

        private bool IsAValidEmail(string email)
        {
           
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        private List<KeyValuePair<string, string>> GetLoginData()
        {
            var result = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("daviquesan@gmail.com", "123456789"),
                new KeyValuePair<string, string>("dOlivo@gmail.com", "soyFalconez"),
                new KeyValuePair<string, string>("eFalconez@gmail.com", "soyOlivo")
            };
            return result;

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}