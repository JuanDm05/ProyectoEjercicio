using System;
using System.Collections.Generic;
using System.Text;
using ProyectoEjercicio.Modelo;
using System.Collections.ObjectModel;


namespace ProyectoEjercicio.Datos
{
    public class Drutinas
    {
        public static ObservableCollection<Mrutinas> MostrarRutinas()
        {
            return new ObservableCollection<Mrutinas>()
            {
                new Mrutinas()
                {
                    descripcion = "Cena",
                    numeroItem = 4512,
                    imagen = "https://i.ibb.co/yn2gWX2/escala-de-satisfaccion.png",
                    backgroundColor = "#EAEDF6",
                    textColor = "#000000"
                },
              
            };
        }
    }
}
