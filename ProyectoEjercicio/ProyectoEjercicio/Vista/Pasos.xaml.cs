using ProyectoEjercicio.Modelo;
using ProyectoEjercicio.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoEjercicio.Vista;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;
using ProyectoEjercicio.Disparadores;


namespace ProyectoEjercicio.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pasos : ContentPage
    {
        private double previousY = 0;
        private int steps = 0;
        private int stepGoal = 100;

        public Pasos()
        {
            InitializeComponent();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            guardarSteps();
        }
        private async Task guardarSteps()
        {
            Msteps msteps = new Msteps();
            VMsteps vmsteps = new VMsteps();
            msteps.pasos = Paso.Text;
            msteps.Dia = dia.Text;

            await vmsteps.InsertarSteps(msteps);
            await DisplayAlert("Alert", "Sigue juantando mas pasos", "Ok");
        }
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs args)
        {
            double x = args.Reading.Acceleration.X;
            double y = args.Reading.Acceleration.Y;
            double z = args.Reading.Acceleration.Z;

            if (previousY > 0 && y <= 0)
            {
                if (Math.Abs(previousY - y) > 1)
                {
                    steps++;
                    Device.BeginInvokeOnMainThread(() => {
                        Paso.Text = $"Pasos: {steps}";
                        UpdateProgressBar(steps); // Actualiza la ProgressBar

                    });
                }
                if (steps % 20 == 0)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await DisplayAlert("Alerta", "Has dado 20 pasos más!", "OK");
                    });
                }
            }

            previousY = y;
        }
        private void Button_Iniciar(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
            {
                steps = 0;
                Paso.Text = "Pasos: 0";
                Accelerometer.Start(SensorSpeed.UI);
            }
        }
        private void UpdateProgressBar(int currentSteps)
        {
            double progress = (double)currentSteps / stepGoal;
            progressBar.ProgressTo(progress, 250, Easing.Linear); 
        }
    }
}