using Xamarin.Forms;

namespace ProyectoEjercicio.Disparadores
{
    public class ChangeColorAction : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            sender.BackgroundColor = Color.DarkOrange;
        }
    }
}
