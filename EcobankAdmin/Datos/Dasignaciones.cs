using EcobankAdmin.Conexiones;
using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas.Confi;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.Datos
{
    public class Dasignaciones
    {
        public async Task<List<Masignaciones>> MostrarAsignaciones()
        {
            var Lista = new List<Masignaciones>();
            var data = (await Constantes.firebase
                .Child("Asignaciones")
                .OrderByKey()
                .OnceAsync<Masignaciones>()).Where(a => a.Key != "Modelo");
            foreach (var item in data)
            {
                var parametros = new Masignaciones();
                parametros.idasignacion = item.Key;
                //parametros.estado = item.Object.estado;
                //parametros.Estado = item.Object.Estado;
                //parametros.Icono = item.Object.Icono;
                //parametros.Idproducto = item.Key;
                //parametros.Preciocompra = "Compra: " + item.Object.Preciocompra;
                //parametros.Precioventa = "Venta: " + item.Object.Precioventa;
                //parametros.Und = item.Object.Und;
                //if (item.Object.Estado == "Activo")
                //{
                //    parametros.Color = "#ECF8EC";
                //    parametros.Colorletraestado = "#29CE69";
                //    parametros.VisibleEstado = "false";
                //    parametros.VisibleElimEdit = "true";
                //}
                //else
                //{
                //    parametros.Color = "#E83C40";
                //    parametros.Colorletraestado = "#FFFFFF";
                //    parametros.VisibleEstado = "true";
                //    parametros.VisibleElimEdit = "false";

                //}
                Lista.Add(parametros);

            }
            return Lista;
        }
        public async Task<bool> Insertarasignaciones(Masignaciones parametros)
        {
            await Constantes.firebase
                .Child("Asignaciones")
                .PostAsync(new Masignaciones()
                {
                    idrecolector = parametros.idrecolector,
                    idsolicitud = parametros.idsolicitud,
                    estado = parametros.estado
                });
            return true;

        }
    }
}
