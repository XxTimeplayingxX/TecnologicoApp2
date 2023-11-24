using TecnologicoApp.MODELS;
using TecnologicoApp.Views;

namespace TecnologicoApp.Views;

public partial class WelcomePage : ContentPage
{
    private UsuarioRegistro usuarioRegistro;

    public UsuarioRegistro UsuarioRegistro { get { return usuarioRegistro; } set => usuarioRegistro = value; }
    public WelcomePage()
	{
		InitializeComponent();
		UsuarioRegistro = new UsuarioRegistro();
		BindingContext = this;
		hola();
	}
	private void hola()
	{
		WelcomeLabel.Text = $"Bienvenido {UsuarioRegistro.Email}";
	}
    
	

	

}