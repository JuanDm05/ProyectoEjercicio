using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoEjercicio
{
    public partial class MainPage : ContentPage
    {
        private double previousY = 0;
        private int steps = 0;

        public MainPage()
        {
            InitializeComponent();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs args)
        {
            double x = args.Reading.Acceleration.X;
            double y = args.Reading.Acceleration.Y;
            double z = args.Reading.Acceleration.Z;

            // Algoritmo simple para detectar un paso
            if (previousY > 0 && y <= 0)
            {
                if (Math.Abs(previousY - y) > 1)
                {
                    steps++;
                    Device.BeginInvokeOnMainThread(() => {
                        stepsResult.Text = $"Pasos: {steps}"; // Actualizar el texto en el hilo principal
                    });
                }
            }

            previousY = y;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
            {
                steps = 0;
                stepsResult.Text = "Pasos: 0";
                Accelerometer.Start(SensorSpeed.UI);
            }
        }
    }
}
