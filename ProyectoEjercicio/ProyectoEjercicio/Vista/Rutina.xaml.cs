using ProyectoEjercicio.Modelo;
using ProyectoEjercicio.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ProyectoEjercicio.Vista;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoEjercicio.Datos;
using ProyectoEjercicio.Disparadores;
using ProyectoEjercicio.Servicios;


namespace ProyectoEjercicio.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rutina : ContentPage 
	{
		public Rutina ()
		{
			InitializeComponent ();
            BindingContext = new VMrutina();

            mostrarRutin();
		}
        private async Task mostrarRutin()
        {
            VMrutina vmr = new VMrutina();
            var dt = await vmr.Mostrar_Rutinas();
            ListaEjercicios.ItemsSource = dt;

        }
        private async Task guardarReps()
        {
            Mrutinas mrutinas = new Mrutinas();
            VMrutina vMrutina = new VMrutina();
            mrutinas.repeticiones = repes.Text;
            mrutinas.Ejercicio = ejer.Text;

            await vMrutina.InsertarRutina(mrutinas);
            await mostrarRutin();
        }
        private async Task ActivarAnimacionTemporalmente()
        {
            var viewModel = BindingContext as VMrutina;
            if (viewModel != null)
            {
                viewModel.ActivadorAnimacionImg = true;
                await Task.Delay(7000); 
                viewModel.ActivadorAnimacionImg = false;
            }
        }
        private void guardarReps(object sender, EventArgs e)
        {
            guardarReps();

            // Llama al método asincrónico para activar la animación temporalmente.
            // No necesitas establecer ActivadorAnimacionImg en true aquí, ya que ActivarAnimacionTemporalmente() se encarga de ello.
            ActivarAnimacionTemporalmente();

        }
        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            VMrutina vmrutina = new VMrutina();
            var button = (Button)sender;
            var idRutina = (string)button.CommandParameter;
            await vmrutina.EliminarRutina(idRutina);

            await mostrarRutin();
        }
      



    }
}