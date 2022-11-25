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
   public class Destaticos
    {
        public async Task<List<Mestaticos>> Mostrarestaticos()
        {
            return (await Constantes.firebase
                     .Child("Estaticos")
                     .OnceAsync<Mestaticos>()).Select(item => new Mestaticos
                     {
                         Puntosmeta = item.Object.Puntosmeta
                     }).ToList();
        }
    }
}
