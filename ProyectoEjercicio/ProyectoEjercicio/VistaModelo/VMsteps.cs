using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProyectoEjercicio.VistaModelo;
using ProyectoEjercicio.Modelo;
using ProyectoEjercicio.Servicios;
using Firebase.Database.Query;

namespace ProyectoEjercicio.VistaModelo
{
    public class VMsteps
    {
        public List<Msteps> steps = new List<Msteps>();
        string idPasos;
        public async Task<List<Msteps>> Mostrar_Sprint()
        {
            var sprint = await Conexionfirebase.firebase.Child("Sprints").OnceAsync<Msteps>();
            foreach (var carrera in sprint)
            {
                Msteps msteps = new Msteps();
                msteps.id_sprint = carrera.Key;
                msteps.pasos = carrera.Object.pasos;
                msteps.Dia = carrera.Object.Dia;

                steps.Add(msteps);
            }
            return steps;
        }
        public async Task<string> InsertarSteps(Msteps parametro)
        {
           var data = await Conexionfirebase.firebase
                .Child("Sprints")
                .PostAsync(new Msteps()
                {
                    pasos = parametro.pasos,
                    Dia = parametro.Dia,
                });
            idPasos = data.Key;
            return idPasos;
        }
       
        public async Task EliminarStep(string idSprint)
        {
            await Conexionfirebase.firebase.Child("Sprints").Child(idSprint).DeleteAsync();
        }


    }
}
