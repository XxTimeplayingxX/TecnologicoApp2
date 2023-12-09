using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnologicoApp.MODELS;

namespace TecnologicoApp.Services.Interfaces
{
    public interface ISignUpSignInService
    {
        public Task<bool> SignUpAsync(UsuarioRegistro usuario);

    }
}
