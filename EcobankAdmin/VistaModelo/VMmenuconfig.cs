using EcobankAdmin.Vistas.Confi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
   public class VMmenuconfig  : BaseViewModel
    {
        public VMmenuconfig(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Listarepartcommand = new Command(async () => await NavegarRepartConfig());
            Volvercommand = new Command(async () => await Volver());
            Listaproductoscommand = new Command(async () => await NavegarListaproductos());
        }
        #region Procesos
        private async Task NavegarRepartConfig()
        {
            await Navigation.PushAsync(new Listarepart());
        }
        private async Task NavegarListaproductos()
        {
            await Navigation.PushAsync(new ListaProductos());
        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region comandos
        public Command Listarepartcommand { get; }
        public Command Volvercommand { get; }
        public Command Listaproductoscommand { get; }
        #endregion
    }
}
