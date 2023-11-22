using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologicoApp.MODELS
{
    public static class Settings
    {
        public static bool IsAuthenticated
        {
            get => Preferences.Default.Get(nameof(IsAuthenticated), false);
            set => Preferences.Default.Set(nameof(IsAuthenticated), value);
        }

        //public static bool IsAuthenticated { get; set; }
    }
}
