using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoApp.MODELS;
using TecnologicoApp.Views;

namespace TecnologicoApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public static WelcomePage Instance {get; set;} = new WelcomePage();
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

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
            List<string> ListaUsuario = new List<string>
            {
                "daviquesan@gmail.com",
                "dolvi123@gmail.com",
                "ofalconez1978@gmail.com",
                "d1sanchez@gmail.com",
                "david@istlcg.com",
                "gus@mail.com"
            };

            bool estaEnLaLista = ListaUsuario.Contains(Usuario.Email);

            if (estaEnLaLista)
            {
                Settings.IsAuthenticated = true;
                await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
                
            }
            else
            {
                await Util.ShowToastAsync("Correo No Registrado");
            }


            //Settings.IsAuthenticated = true;

            
        }
        public void OtraPagina()
        {
            string mensaje = $"Bienvenido {Usuario.Email}";
        }

        private bool IsAValidEmail(string email)
        {
           
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}