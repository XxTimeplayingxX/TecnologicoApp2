using System.ComponentModel;
using System.Runtime.CompilerServices;
using Settings = TecnologicoApp.MODELS.Settings;

namespace TecnologicoApp.ViewModels
{
    public class WelcomePageViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public WelcomePageViewModel()
        {
            Email = Settings.Email;            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
