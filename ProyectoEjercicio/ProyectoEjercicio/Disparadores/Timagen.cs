using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEjercicio.Disparadores
{
    public class Timagen : TriggerAction<Image>
    {
        public bool activation { get; set; }
        protected override async void Invoke(Image sender)
        {
            if (activation == true)
            {
                sender.BackgroundColor = Color.Aqua;
                sender.Source = ImageSource.FromUri(new Uri("https://i.ibb.co/yn2gWX2/escala-de-satisfaccion.png"));
                await sender.RelRotateTo(360, 5000, Easing.BounceOut);
            }
            if (activation == false)
            {
                sender.BackgroundColor = new Image().BackgroundColor;
                sender.Rotation = new Image().Rotation;
                sender.Source = null; 
            }

        }
    }
}
