using ProyectoEjercicio.Modelo;
using ProyectoEjercicio.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoEjercicio.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarPasos : ContentPage
    {
        public MostrarPasos()
        {
            InitializeComponent();
            mostrarPasos();
            
        }
        private async Task mostrarPasos()
        {
            VMsteps vmsteps = new VMsteps();
            var dt = await vmsteps.Mostrar_Sprint();
            listaPasos.ItemsSource = dt;

        }
        private async Task Eliminar()
        {
            VMsteps vmsteps = new VMsteps();
            //await vmsteps.EliminarTodosLosSteps();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Eliminar();
        }
        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            VMsteps vMsteps = new VMsteps();
            var button = (Button)sender;
            var idSprint = (string)button.CommandParameter;
            await vMsteps.EliminarStep(idSprint);

            await mostrarPasos();
        }


    }
}