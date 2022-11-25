using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;
using System.IO;
using Firebase.Storage;
using Xamarin.Forms;

namespace EcobankAdmin.Datos
{
    public class Drecolectores
    {
        public async Task<bool> InsertarRecolectores(Mrecolectores parametros)
        {
            await Constantes.firebase
                .Child("Recolectores")
                .PostAsync(new Mrecolectores()
                {
                    Correo = parametros.Correo,
                    Estado = parametros.Estado,
                    Identificacion = parametros.Identificacion,
                    Nombre = parametros.Nombre

                });
            return true;

        }
        public async Task<List<Mrecolectores>> MostrarRecolectores()
        {
            var ListaRepart = new List<Mrecolectores>();
            var data = (await Constantes.firebase
                .Child("Recolectores")
                .OrderByKey()
                .OnceAsync<Mrecolectores>());
            foreach (var item in data)
            {
                var parametros = new Mrecolectores();
                parametros.Nombre = item.Object.Nombre;
                parametros.Identificacion = "[" + item.Object.Identificacion + "]";
                parametros.Estado = item.Object.Estado;
                parametros.Correo = item.Object.Correo;
                parametros.Idrecolectores = item.Key;
                if (item.Object.Estado == "Activo")
                {
                    parametros.Color = "#ECF8EC";
                    parametros.Colorletraestado = "#29CE69";
                    parametros.VisibleEstado = "false";
                    parametros.VisibleElimEdit = "true";
                }
                else
                {
                    parametros.Color = "#E83C40";
                    parametros.Colorletraestado = "#FFFFFF";
                    parametros.VisibleEstado = "true";
                    parametros.VisibleElimEdit = "false";

                }
                ListaRepart.Add(parametros);

            }
            return ListaRepart;
        }
        public async Task ActivarRecolector(Mrecolectores parametrospedir)
        {
            var data = (await Constantes.firebase
              .Child("Recolectores")
              .OnceAsync<Mrecolectores>()).Where(a => a.Key == parametrospedir.Idrecolectores).FirstOrDefault();

            data.Object.Estado = "Activo";
            await Constantes.firebase
              .Child("Recolectores")
              .Child(data.Key)
              .PutAsync(data.Object);


        }
        public async Task Eliminarrecolector(Mrecolectores parametrospedir)
        {
            var data = (await Constantes.firebase
              .Child("Recolectores")
              .OnceAsync<Mrecolectores>()).Where(a => a.Key == parametrospedir.Idrecolectores).FirstOrDefault();

            data.Object.Estado = "Suspendido";
            await Constantes.firebase
              .Child("Recolectores")
              .Child(data.Key)
              .PutAsync(data.Object);

        }
        public async Task<List<Mrecolectores>> BuscarRecolectores(Mrecolectores parametrosppedir)
        {
            return(await Constantes.firebase
                .Child("Recolectores")
                .OrderByKey()
                .OnceAsync<Mrecolectores>()).Where(a => a.Object.Identificacion == parametrosppedir.Identificacion).Where(b => b.Object.Estado == "Activo").Select(item => new Mrecolectores
                {
                    Idrecolectores=item.Key,
                    Nombre=item.Object.Nombre
                }).ToList();
        }
    }

}
