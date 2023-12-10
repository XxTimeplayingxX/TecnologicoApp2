using CommunityToolkit.Maui.Converters;
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
        public static string Email
        {
            //Valor por defecto
            get => Preferences.Default.Get(nameof(Email), string.Empty);
            //Valor que se va a mandar
            set => Preferences.Default.Set(nameof(Email), value);
        }

        public static string RegistroEmail
        {
            get => Preferences.Default.Get(nameof(RegistroEmail), string.Empty);
            set => Preferences.Default.Set(nameof(RegistroEmail), value);
        }
        public static string RegistroPassword
        {
            get => Preferences.Default.Get(nameof(RegistroPassword), string.Empty);
            set => Preferences.Default.Set(nameof(RegistroPassword), value);
        }

        //public static bool IsRegistered
        //{
        //    get => Preferences.Default.Get(nameof(IsRegistered), false);
        //    set => Preferences.Default.Set(nameof(IsRegistered), value);
        //}
    }
}
