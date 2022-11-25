using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas;
using EcobankAdmin.Vistas.Confi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
   public class VMmenuprincipal : BaseViewModel
    {
        public List<Msolicitudesrecojo> listViewSource;
        bool isBusy = false;
        bool sinsolicitudes;
        bool consolicitudes;
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            NavegarMenuconfigcommad = new Command(async () => await NavegarMenuconfig());
            Navegarasignacionescommad = new Command<Msolicitudesrecojo>(async (f) => await Navegarasignaciones(f));
            Sinsolicitudes = false;
            Consolicitudes = false;
            MostrarSolicitudes();
        }
        #region Procesos
        private async Task NavegarMenuconfig()
        {
            await Navigation.PushAsync(new Menuconfig());
        }
        private async Task Navegarasignaciones(Msolicitudesrecojo solicitudes)
        {
            await Navigation.PushAsync(new Agregarasignacion(solicitudes));
        }
        #endregion
        public async Task MostrarSolicitudes()
        {
           

            Listasolicitudes = new List<Msolicitudesrecojo>(new List<Msolicitudesrecojo>
            {
                new Msolicitudesrecojo
                {
                    Nombrecliente="Some",
                    ubicacioncompleta="Some",
                    IsBusy=true,
                    turno="fake data"
                },
                  new Msolicitudesrecojo
                {
                    Nombrecliente="Some",
                     ubicacioncompleta="Some",
                    IsBusy=true,
                    turno="fake data"
                },
                    new Msolicitudesrecojo
                {
                    Nombrecliente="Some",
                     ubicacioncompleta="Some",
                    IsBusy=true,
                    turno="fake data"
                }
            });
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;

            var funcion = new Dsolicitudesrecojo();
            this.Listasolicitudes = await funcion.MostrarsolicitRecojo();
           
            if(Listasolicitudes.Count==0)
            {
                Sinsolicitudes = true;
                Consolicitudes = false;
            }
            else
            {
                Sinsolicitudes = false;
                Consolicitudes = true;
            }
        }
        public List<Msolicitudesrecojo> Listasolicitudes
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        #region comandos
      

        public Command NavegarMenuconfigcommad { get; }
        public Command Navegarasignacionescommad { get; }
        #endregion
        #region objetos
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetValue(ref sinsolicitudes, value);
            }
        }
        public bool Sinsolicitudes
        {
            get { return this.sinsolicitudes; }
            set
            {
                SetValue(ref this.sinsolicitudes, value);
            }
        }
        public bool Consolicitudes
        {
            get { return this.consolicitudes; }
            set
            {
                SetValue(ref this.consolicitudes, value);
            }
        }
        #endregion
    }
}
