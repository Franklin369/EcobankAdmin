using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;

namespace EcobankAdmin.Datos
{
   public  class Dturnosrecojos
    {
        public async Task<List<Mturnosrecojo>> Mostrarturnosrecojo()
        {

            return (await Constantes.firebase
              .Child("Turnosrecojo")
              .OnceAsync<Mturnosrecojo>()).Select(item => new Mturnosrecojo
              {
                  Idturno = item.Key,
                  Turno = item.Object.Turno
              }).ToList();

        }
        public async Task<string> MostrarturnosrecojoXid(Msolicitudesrecojo parametros)
        {

            var data= (await Constantes.firebase
              .Child("Turnosrecojo")
              .OnceAsync<Mturnosrecojo>()).Where(a => a.Key == parametros.Idturno).FirstOrDefault();
            return data.Object.Turno;
        }
    }
}
