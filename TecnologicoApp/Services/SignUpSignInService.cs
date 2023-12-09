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
            string ejemplo1 = null;
            string ejemplo2 = string.Empty;
            string ejemplo3 = " ";
            
            Settings.RegistroEmail = usuario.Email;
            Settings.RegistroPassword = usuario.Password;
            
        }
    }
}
