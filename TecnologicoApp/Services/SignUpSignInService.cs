using TecnologicoApp.MODELS;
using TecnologicoApp.Services.Interfaces;

namespace TecnologicoApp.Services;

class SignUpSignInService : ISignUpSignInService
{
    public async Task<bool> SignUpAsync(UsuarioRegistro usuario)
    {
        await Task.Delay(1000);//Ahora ya es asíncrónico
        
        if(usuario == null || 
            string.IsNullOrWhiteSpace(usuario.Password) || 
            string.IsNullOrWhiteSpace(usuario.Email))
        {
            return false;
        }
        
        Settings.RegistroEmail = usuario.Email;
        Settings.RegistroPassword = usuario.Password;
        //Settings.IsRegistered = true;

        return true;
    }
}
