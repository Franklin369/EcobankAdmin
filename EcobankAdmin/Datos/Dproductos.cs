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
   public class Dproductos
    {
        public async Task<bool> InsertarProductos(Mproductos parametros)
        {
            await Constantes.firebase
                .Child("Productos")
                .PostAsync(new Mproductos()
                {
                    Descripcion = parametros.Descripcion,
                    Estado = parametros.Estado,
                    Preciocompra = parametros.Preciocompra,
                    Precioventa = parametros.Precioventa,
                    Color=parametros.Color,
                    Icono=parametros.Icono,
                    Und=parametros.Und  
                });
            return true;

        }
        public async Task<List<Mproductos>> MostrarProductos()
        {
            var Lista = new List<Mproductos>();
            var data = (await Constantes.firebase
                .Child("Productos")
                .OrderByKey()
                .OnceAsync<Mproductos>()).Where(a=>a.Key!="Modelo");
            foreach (var item in data)
            {
                var parametros = new Mproductos();
                parametros.Color = item.Object.Color;
                parametros.Descripcion = item.Object.Descripcion;
                parametros.Estado = item.Object.Estado;
                parametros.Icono = item.Object.Icono;
                parametros.Idproducto = item.Key;
                parametros.Preciocompra ="Compra: "+ item.Object.Preciocompra;
                parametros.Precioventa ="Venta: " + item.Object.Precioventa;
                parametros.Und = item.Object.Und;
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
                Lista.Add(parametros);

            }
            return Lista;
        }
        public async Task ActivarProducto(Mrecolectores parametrospedir)
        {
            var data = (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mrecolectores>()).Where(a => a.Key == parametrospedir.Idrecolectores).FirstOrDefault();

            data.Object.Estado = "Activo";
            await Constantes.firebase
              .Child("Productos")
              .Child(data.Key)
              .PutAsync(data.Object);


        }
        public async Task EliminarProducto(Mrecolectores parametrospedir)
        {
            var data = (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mrecolectores>()).Where(a => a.Key == parametrospedir.Idrecolectores).FirstOrDefault();

            data.Object.Estado = "Suspendido";
            await Constantes.firebase
              .Child("Productos")
              .Child(data.Key)
              .PutAsync(data.Object);

        }
       
        public async Task<List<Mproductos>> MostrarProductos2()
        {

            return (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mproductos>()).Select(item => new Mproductos
              {

                  Preciocompra = item.Object.Preciocompra,
                  PreciocompraString = "Precio de compra por" + item.Object.Und + " = S/." + item.Object.Preciocompra,
                  Descripcion = item.Object.Descripcion,
                  Icono = item.Object.Icono,
                  Color = item.Object.Color,
                  Und = item.Object.Und
                  ,
                  Idproducto = item.Key

              }).ToList();
        }
        public async Task<List<Mproductos>> MostrarProductoXid(Mproductos parametrosPedir)
        {

            return (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mproductos>()).Where(a => a.Key == parametrosPedir.Idproducto).Select(item => new Mproductos
              {

                  Preciocompra = item.Object.Preciocompra,
                  PreciocompraString = "Precio de compra por" + item.Object.Und + " = S/." + item.Object.Preciocompra,
                  Descripcion = item.Object.Descripcion,
                  Icono = item.Object.Icono,
                  Color = item.Object.Color,
                  Und = item.Object.Und
                  ,
                  Idproducto = item.Key

              }).ToList();
        }
     
    }
}
