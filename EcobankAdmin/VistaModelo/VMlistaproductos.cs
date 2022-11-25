using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas.Confi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
   public class VMlistaproductos:BaseViewModel
    {
        #region variables
        public object listaProduct;
        #endregion
        #region Constructor
        public VMlistaproductos(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Agregarcommand = new Command<Mproductos>(async (f) => await NavegarAgregar(f));
            Eliminarcommand = new Command<Mproductos>(async (f) => await Eliminar(f));
            Activarcommand = new Command<Mproductos>(async (f) => await Activar(f));
            Editarcommand = new Command<Mproductos>(async (f) => await Editar(f));
            Volvercommand = new Command(async () => await Volver());
            ListarProductos();
        }

        #endregion


        #region Objetos
        public object ListProductos
        {
            get { return this.listaProduct; }
            set
            {
                SetValue(ref this.listaProduct, value);
            }
        }
        #endregion
        #region Procesos
        private async Task Eliminar(Mproductos recolectores)
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.Idproducto = recolectores.Idproducto;
            //await funcion.EliminarProducto(parametros);
            //await ListarProductos();
        }
        private async Task Activar(Mproductos recolectores)
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.Idproducto = recolectores.Idproducto;
            //await funcion.ActivarRecolector(parametros);
            //await ListarProductos();
        }
        private async Task Editar(Mproductos productos)
        {
            //VMagregarrecolect.ActivarEdicion = true;
            //await Navigation.PushAsync(new AgregarRecolect(productos));
        }
        private async Task NavegarAgregar(Mproductos productos)
        {
            VMagregarproductos.ActivarEdicion = false;
            await Navigation.PushAsync(new AgregarProducto(productos));
        }
        public async Task ListarProductos()
        {
            var funcion = new Dproductos();
            ListProductos = await funcion.MostrarProductos();

        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region comandos
        public Command Agregarcommand { get; }
        public Command Eliminarcommand { get; }
        public Command Activarcommand { get; }
        public Command Editarcommand { get; }
        public Command Volvercommand { get; }
        #endregion
    }
}
