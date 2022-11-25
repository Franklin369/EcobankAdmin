using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;
using EcobankAdmin.VistaModelo;

namespace EcobankAdmin.Datos
{
    public class Ddetallecompra
    {
        List<Mdetallecompra> Catalogo = new List<Mdetallecompra>();
        public async Task InsertarDetallecompra(Mdetallecompra parametros)
        {


            await Constantes.firebase
                    .Child("Detallecompra")
                    .PostAsync(new Mdetallecompra()
                    {

                        fecha = DateTime.Now.ToString(),
                        Ganancia = parametros.Ganancia,
                        Idcliente = parametros.Idcliente,
                        Idproducto = parametros.Idproducto,
                        Cantidad = parametros.Cantidad,
                        Preciocompra = parametros.Preciocompra,
                        PrecioVenta = parametros.PrecioVenta,
                        Total = parametros.Total,
                        Und = parametros.Und,
                        Puntos = parametros.Puntos
                    });
        }
        public async Task<List<Mdetallecompra>> MostrarDcompra(string Idcliente)
        {

            var data = (await Constantes.firebase
           .Child("Detallecompra")
           .OrderByKey()

           .OnceAsync<Mdetallecompra>()).Where(a => a.Object.Idcliente == Idcliente);
            foreach (var dino in data)
            {
                var parametros = new Mdetallecompra();
                parametros.Preciocompra = "Precio de compra por " + dino.Object.Und + " = S/." + dino.Object.Preciocompra;
                parametros.Cantidad = dino.Object.Cantidad;
                parametros.Total ="S/. " + dino.Object.Total;
                parametros.Und = dino.Object.Und;
                parametros.fecha = dino.Object.fecha;
                var funcionProductos = new Dproductos();
                var parametrosProduc = new Mproductos();
                parametrosProduc.Idproducto = dino.Object.Idproducto;
                var dt = await funcionProductos.MostrarProductoXid(parametrosProduc);
                foreach (var dtpro in dt)
                {
                    parametros.Producto = dtpro.Descripcion + " ("+parametros.Cantidad+" "+ parametros.Und+ ")";
                    parametros.ProducIcono = dtpro.Icono;
                    parametros.Color = dtpro.Color;
                }

                Catalogo.Add(parametros);
            }
            return Catalogo.ToList();

        }
        public async Task<List<Mdetallecompra>> MostrarDcompra2(string Idcliente)
        {

            return (await Constantes.firebase
              .Child("Detallecompra")
              .OnceAsync<Mdetallecompra>()).Where(a => a.Object.Idcliente == Idcliente).Select(item => new Mdetallecompra
              {
                  Cantidad = item.Object.Cantidad,
                  Preciocompra = "Precio de compra por " + item.Object.Und + " = S/." + item.Object.Preciocompra,
                  //Descripcion = item.Object.Descripcion,
                  //Icono = item.Object.Icono,
                  //Color = item.Object.Color,
                  //Und = item.Object.Und
                  //,
                  //Idproducto = item.Key

              }).ToList();
        }
    }
}
