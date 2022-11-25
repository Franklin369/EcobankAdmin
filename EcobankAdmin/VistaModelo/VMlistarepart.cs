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
    public class VMlistarepart : BaseViewModel
    {
        #region variables
        public object listaRecolectores;
        #endregion
        #region Constructor
        public VMlistarepart(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            AgregarRepartcommand = new Command<Mrecolectores>(async (f) => await NavegarRepartConfig(f));
            Eliminarcommand = new Command<Mrecolectores>(async (f)=>await EliminarRepartidor(f));
            Activarcommand = new Command<Mrecolectores>(async (f) => await ActivarRepartidor(f));
            Editarcommand = new Command<Mrecolectores>(async (f) => await Editar(f));
            Volvercommand = new Command(async () => await Volver());
            ListarRepart();
        }

        #endregion


        #region Objetos
        public object Listarecolectores
        {
            get { return this.listaRecolectores; }
            set
            {
                SetValue(ref this.listaRecolectores, value);
            }
        }
        #endregion
        #region Procesos
        private async Task EliminarRepartidor(Mrecolectores recolectores)
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Idrecolectores = recolectores.Idrecolectores;
            await funcion.Eliminarrecolector(parametros);
            await ListarRepart();
        }
        private async Task ActivarRepartidor(Mrecolectores recolectores)
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Idrecolectores = recolectores.Idrecolectores;
            await funcion.ActivarRecolector(parametros);
            await ListarRepart();
        }
        private async Task Editar(Mrecolectores recolectores)
        {
            VMagregarrecolect.ActivarEdicion = true;
            await Navigation.PushAsync(new AgregarRecolect(recolectores));
        }
        private async Task NavegarRepartConfig(Mrecolectores recolectores)
        {
            VMagregarrecolect.ActivarEdicion = false;
            await Navigation.PushAsync(new AgregarRecolect(recolectores));
        }
        public async Task ListarRepart()
        {
            var funcion = new Drecolectores();
            Listarecolectores = await funcion.MostrarRecolectores();

        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region comandos
        public Command AgregarRepartcommand { get; }
        public Command Eliminarcommand { get; }
        public Command Activarcommand { get; }
        public Command Editarcommand { get; }
        public Command Volvercommand { get; }
        #endregion
    }
}
