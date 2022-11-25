using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using GalaSoft.MvvmLight.Command;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcobankAdmin.Vistas;
using Xamarin.Essentials;
using Plugin.SharedTransitions;

namespace EcobankAdmin.VistaModelo
{
    public class VMlogin : BaseViewModel
    {

        private string identificacion;
        private string pass;
        private int contadorLogin = 0;
        public object listViewSource;
        public bool visibleInicio = true;
        public bool visiblefinal = false;
        public bool sininternetV = false;

        Mclientes client = new Mclientes();
        public VMlogin(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Logincommand = new Command<Musuarios>(async (param) => await ExecutarValidacion(param));

            VisibleFinal = false;
            Sininternetv = false;
            ValidarConexInternet();
        }
        private void ValidarConexInternet()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                VisibleInicio = false;
                Sininternetv = true;
            }
            else
            {
                VisibleInicio = true;
                Sininternetv = false;
            }
        }
        public Command Logincommand { get; }
        #region Propertiers
        public string Correotxt
        {
            get { return this.identificacion; }
            set { SetValue(ref this.identificacion, value); }
        }
        public string Passtxt
        {
            get { return this.pass; }
            set { SetValue(ref this.pass, value); }
        }
        #endregion
        #region Commands

        #endregion
        #region Metodos
        async Task Validarlogin(Musuarios client)
        {
            VisibleInicio = false;
            VisibleFinal = true;
            var funcion = new Dusuarios();
            var parametros = new Musuarios();
            var funcionesta = new Destaticos();
            var dtest = await funcionesta.Mostrarestaticos();
            parametros.correo = Correotxt;
            parametros.pass = Passtxt;
            var estado = await funcion.ValidarCuenta(parametros);
            if (estado == true)
            {
                Application.Current.MainPage = new SharedTransitionNavigationPage(new Menuprincipal());
            }
            else
            {
                VisibleInicio = true;
                VisibleFinal = false;
                await Application.Current.MainPage.DisplayAlert("Datos incorrectos", "No se encontro registros", "OK");
            }
        }
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        public bool VisibleInicio
        {
            get { return this.visibleInicio; }
            set
            {
                SetValue(ref this.visibleInicio, value);
            }
        }
        public bool VisibleFinal
        {
            get { return this.visiblefinal; }
            set
            {
                SetValue(ref this.visiblefinal, value);
            }
        }
        public bool Sininternetv
        {
            get { return this.sininternetV; }
            set
            {
                SetValue(ref this.sininternetV, value);
            }
        }
        private async Task ExecutarValidacion(Musuarios client)
        {
            await Validarlogin(client);

        }

        #endregion
    }
}
