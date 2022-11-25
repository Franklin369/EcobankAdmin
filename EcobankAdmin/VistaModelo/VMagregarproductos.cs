using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;
using System.Collections.ObjectModel;
using Firebase.Database;
using Xamarin.Forms;
using EcobankAdmin.Datos;

namespace EcobankAdmin.VistaModelo
{
    public class VMagregarproductos : BaseViewModel
    {
        #region variables
        public object listaRecolectores;

        public string descripcion;
        public string preciocompra;
        public string precioventa;
        public string unidadmedida;
        public string color;
        public string estado;
        public string icono;

        public static bool ActivarEdicion;
        public Mproductos Productos { get; set; }
        public bool estadosedicionPass;

        #endregion
        #region Constructor
        public VMagregarproductos(INavigation navigation, Mproductos productos)
        {
            Navigation = navigation;
            InsertarProductcomman = new Command(async () => await InsertarProductos());
            //Volvercomman = new Command(async (param) => await Volver());
            Productos = productos;
            Recuperardatos();
        }
        private void Recuperardatos()
        {
            //if (ActivarEdicion == true)
            //{
            //    //txtNombre = Recolectores.Nombre;
            //    //txtCorreo = Recolectores.Correo;
            //    //txtIdentificacion = Recolectores.Identificacion;
            //    EstadoVisPass = false;
            //}
            //else
            //{
            //    EstadoVisPass = true;
            //}

        }
        #endregion
        #region Objetos

        public string txtDescripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                SetProperty(ref descripcion, value);
            }
        }
        public string txtPreciocompra
        {
            get
            {
                return preciocompra;
            }
            set
            {
                SetProperty(ref preciocompra, value);
            }
        }
        public string txtPrecioventa
        {
            get
            {
                return precioventa;
            }
            set
            {
                SetProperty(ref precioventa, value);
            }
        }
        public string txtUndmedida
        {
            get
            {
                return unidadmedida;
            }
            set
            {
                SetProperty(ref unidadmedida, value);
            }
        }
        public string txtColor
        {
            get
            {
                return color;
            }
            set
            {
                SetProperty(ref color, value);
            }
        }
        public string txtIcono
        {
            get
            {
                return icono;
            }
            set
            {
                SetProperty(ref icono, value);
            }
        }
        #endregion
        #region procesos
        private async Task InsertarProductos()
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.Descripcion = txtDescripcion;
            parametros.Preciocompra = txtPreciocompra;
            parametros.Precioventa = txtPrecioventa;
            parametros.Icono = txtIcono;
            parametros.Color = txtColor;
            parametros.Und = txtUndmedida;
            parametros.Estado = "Activo";
            var estado = await funcion.InsertarProductos(parametros);
            if (estado == true)
            {
                await DisplayAlert("Hecho", "Registro exitoso", "OK");
                await Volver();
            }
        }

        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion

        #region comandos
        public Command InsertarProductcomman { get; set; }
        public Command EditarRecoleccomman { get; set; }
        public Command Volvercomman { get; }
        #endregion



    }
}
