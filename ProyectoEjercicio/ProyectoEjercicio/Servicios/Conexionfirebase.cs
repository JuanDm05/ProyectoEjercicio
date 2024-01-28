using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace ProyectoEjercicio.Servicios
{
    public class Conexionfirebase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://fitproject-22926-default-rtdb.asia-southeast1.firebasedatabase.app/");
    }
}
