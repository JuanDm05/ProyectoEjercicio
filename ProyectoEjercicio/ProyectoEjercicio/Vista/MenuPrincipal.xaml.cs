using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEjercicio.Vista
    ;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoEjercicio.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private async void Cardio_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pasos());
        }
        private async void Historial_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarPasos());
        } 
        private async void Rutina_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rutina());
        }
    }
}