using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProyectoEjercicio.VistaModelo;

namespace ProyectoEjercicio.Modelo
{
    public class Mrutinas : BaseViewModel
    {
 

        public string id_rutina { get; set; }
        public string Ejercicio { get; set; }
        public string repeticiones { get; set; }

        public bool _selected;




        //RUTINAS IMG
        public string descripcion;
        public int numeroItem;
        public string imagen;
        public string _backgroundColor;
        public string _textColor;

        public string backgroundColor
        {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value); }
        }
        public string textColor
        {
            get { return _textColor; }
            set { SetProperty(ref _textColor, value); }
        }
         public bool selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }
    }
}

