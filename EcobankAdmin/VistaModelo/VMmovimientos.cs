using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;
namespace EcobankAdmin.VistaModelo
{
   public class VMmovimientos
    {
        public async Task<List<Mmovimientos>> MostrarMovimientos()
        {
            var Movimientos = new List<Mmovimientos>();
            var data = (await Constantes.firebase
                .Child("Movimientos")
                .OrderByKey()
                .OnceAsync<Mmovimientos>());
            foreach (var dt in data)
            {
                var parametros = new Mmovimientos();
                parametros.Fecha = dt.Object.Fecha;
                parametros.Kg = dt.Object.Kg;
                parametros.Idcategoria = dt.Object.Idcategoria;
                parametros.Total = dt.Object.Total;
                parametros.Movimiento = dt.Object.Kg+" de " + dt.Object.Idcategoria;

              
                Movimientos.Add(parametros);
            }
            return Movimientos;
        }
        public async Task InsertarMovimientos(Mmovimientos parametros)
        {

            await Constantes.firebase
                .Child("Movimientos")
                .PostAsync(new Mmovimientos()
                {
                    Fecha = parametros.Fecha,
                    Idcategoria = parametros.Idcategoria,
                    Kg = parametros.Kg,
                    Movimiento = parametros.Movimiento,
                    Total = parametros.Total

                });
        }
    }
}
