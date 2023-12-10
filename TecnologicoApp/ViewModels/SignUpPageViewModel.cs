using System.ComponentModel;
using TecnologicoApp.MODELS;

namespace TecnologicoApp.ViewModels;

public class SignUpPageViewModel : INotifyPropertyChanged
{
    public UsuarioRegistro Usuario { get; set; }

    public Command SaveCommand { get; set; }
    public string Password2 { get; set; } = string.Empty;
    public SignUpPageViewModel()
    {
        Usuario = new UsuarioRegistro();//Creamos la instancia
        SaveCommand = new Command(SaveAsync);//
    }
    private async void SaveAsync()
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
        if (string.IsNullOrEmpty(Password2))
        {
            await Util.ShowToastAsync("Ingrese una Contraseña Válida");
            return;
        }
        if(Usuario.Password != Password2)
        {
            await Util.ShowToastAsync("Las contraseñas no son iguales");
            return;
        }
        Settings.RegistroEmail = Usuario.Email;
        Settings.RegistroPassword = Usuario.Password;
        await Shell.Current.Navigation.PopAsync();
    }





    public event PropertyChangedEventHandler PropertyChanged;
}
