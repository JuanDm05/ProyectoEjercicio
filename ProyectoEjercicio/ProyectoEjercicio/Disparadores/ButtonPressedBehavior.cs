using System;
using Xamarin.Forms;

namespace ProyectoEjercicio.Disparadores
{
    public class ButtonPressedBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            base.OnAttachedTo(button);
            button.Pressed += OnButtonPressed;
        }

        protected override void OnDetachingFrom(Button button)
        {
            button.Pressed -= OnButtonPressed;
            base.OnDetachingFrom(button);
        }

        private void OnButtonPressed(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.BackgroundColor = Color.DarkOrange;
            button.Text = "Datos guardados";

        }
    }
}
