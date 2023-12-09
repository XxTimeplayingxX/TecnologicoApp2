using TecnologicoApp.MODELS;
using TecnologicoApp.Services.Interfaces;

namespace TecnologicoApp.Services
{
    class SignUpSignInService : ISignUpSignInService
    {
        public async Task<bool> SignUpAsync(UsuarioRegistro usuario)
        {
            var result = false;
            if(usuario == null)
            {
                return result;
            }
            if (usuario.Email == string.Empty)
            {
                return result;
            }
            
            Settings.RegistroEmail = usuario.Email;
            Settings.RegistroPassword = usuario.Password;
            
        }
    }
}
