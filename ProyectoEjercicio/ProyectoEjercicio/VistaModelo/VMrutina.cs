using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Database.Query;
using ProyectoEjercicio.Datos;
using ProyectoEjercicio.Modelo;
using ProyectoEjercicio.Servicios;
using ProyectoEjercicio.Vista;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ProyectoEjercicio.VistaModelo
{
    public class VMrutina : BaseViewModel
    {
        bool _activadorAnimacionImg;
        string _imagen;
        ObservableCollection<Mrutinas> _listaRutinas;

        public bool ActivadorAnimacionImg
        {
            get { return _activadorAnimacionImg; }
            set { SetValue(ref _activadorAnimacionImg, value); }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        public ObservableCollection<Mrutinas> ListaRutinas
        {
            get { return _listaRutinas; }
            set { SetValue(ref _listaRutinas, value); }
        }
        List<Mrutinas> rutinass = new List<Mrutinas>();

        string idRutinas;
        public void Seleccionar(Mrutinas modelo)
        {
            var index = ListaRutinas
                .ToList()
                .FindIndex(p => p.descripcion == modelo.descripcion);
            Imagen = modelo.imagen;
            if (index > -1)
            {
                Deseleccionar();
                ActivadorAnimacionImg = true;
                ListaRutinas[index].selected = true;
                ListaRutinas[index].textColor = "#FFFFFF";
                ListaRutinas[index].backgroundColor = "#FF506B";
            }
        }
        public void Deseleccionar()
        {

            ListaRutinas.ForEach((item) =>
            {
                ActivadorAnimacionImg = false;
                item.selected = false;
                item.textColor = "#000000";
                item.backgroundColor = "#EAEDF6";
            });
        }
        public async Task<List<Mrutinas>> Mostrar_Rutinas()
        {
            var ruti = await Conexionfirebase.firebase
                .Child("Rutina")
                .OnceAsync<Mrutinas>();
            foreach (var work in ruti)
            {
                Mrutinas  mrutinas = new Mrutinas();
                mrutinas.id_rutina = work.Key;
                mrutinas.Ejercicio = work.Object.Ejercicio;
                mrutinas.repeticiones = work.Object.repeticiones;


                rutinass.Add(mrutinas);


            }
            return rutinass;

        }
        public async Task<string> InsertarRutina(Mrutinas parametro)
        {
            var data = await Conexionfirebase.firebase
                 .Child("Rutina")
                 .PostAsync(new Mrutinas()
                 {
                    Ejercicio = parametro.Ejercicio,
                    repeticiones = parametro.repeticiones
                 });
            idRutinas = data.Key;
            return idRutinas;
        }
        
       
        public async Task EliminarRutina(string idRutina)
        {
            await Conexionfirebase.firebase.Child("Rutina").Child(idRutina).DeleteAsync();
        }

        public ICommand ProcesoSimpSeleccionar => new Command<Mrutinas>((p) => Seleccionar(p));
    }
}
