using System;
using Xamarin.Forms;

namespace ProyectoEjercicio.Disparadores
{
    public class CheckboxCheckedTrigger : TriggerAction<CheckBox>
    {
        protected override void Invoke(CheckBox sender)
        {
            if (sender.IsChecked)
            {
                var pulseAnimation = new Animation();
                pulseAnimation.WithConcurrent((f) => sender.Scale = f, sender.Scale, 1.5, Easing.Linear);
                pulseAnimation.WithConcurrent((f) => sender.Opacity = f, sender.Opacity, 0.5, Easing.Linear, 0, 0.5);
                pulseAnimation.WithConcurrent((f) => sender.Scale = f, 1.5, 1, Easing.Linear);
                pulseAnimation.WithConcurrent((f) => sender.Opacity = f, 0.5, 1, Easing.Linear, 0.5, 1);

                pulseAnimation.Commit(sender, "PulseAnimation", 16, 2000);

                Application.Current.MainPage.DisplayAlert("Ejercicio Terminado", " Muy bien sigue asi!", "OK");
            }


        }

        

    }
}