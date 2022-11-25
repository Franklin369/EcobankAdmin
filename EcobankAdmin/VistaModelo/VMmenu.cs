using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using EcobankAdmin;

namespace EcobankAdmin.VistaModelo
{
    public class VMmenu : BaseViewModel
    {
        public int contadorLogin;
        public List<Mdetallecompra> listViewSource=new List<Mdetallecompra>();
        private  string Nombre;
        Ddetallecompra funcion = new Ddetallecompra();
        public VMmenu(INavigation navigation, Musuarios client)
        {
            Navigation = navigation;
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            NavigationPage.SetHasNavigationBar(page, false);
            User = client;
            LoadData();
            //GetCategoriesAsync();
        }
      

        public async Task LoadData()
        {
            var funcion = new Ddetallecompra();
            this.ListViewSource = await funcion.MostrarDcompra(User.correo);
        }
        //public async Task Mostrardetallecompra()
        //{
        //    var funcion = new Ddetallecompra();
        //    //var parametros = new Mdetallecompra();
        //    //parametros.Idcliente = Client.Idcliente;
        //    this.ListViewSource = await funcion.MostrarDcompra();
        //}
        public List<Mdetallecompra> ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        #region Properties
        public Command Logincommand { get; }
        public Command Verdetallescommand { get; }
        public Command SolicitudRecojocommand { get; }

       
      
        public string Nombretxt
        {
            get { return this.Nombre; }
            set { SetValue(ref this.Nombre, value); }
        }
        #endregion
       
       
        public Musuarios User { get; set; }
    }
}
