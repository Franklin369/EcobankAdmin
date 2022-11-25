using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
   public class VMdetallereciclado:BaseViewModel
    {
        public int contadorLogin;
        public List<Mdetallecompra> listViewSource = new List<Mdetallecompra>();
        Ddetallecompra funcion = new Ddetallecompra();
        public VMdetallereciclado(INavigation navigation, Mclientes client)
        {
            Navigation = navigation;
            Client = client;
            //var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            //NavigationPage.SetHasNavigationBar(page, false);
            Volvercomman = new Command(async(param)=>await Volver());
            LoadData();
            //GetCategoriesAsync();
        }

       

        public Command Volvercomman { get; }

        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public Mclientes Client { get; set; }
        public List<Mdetallecompra> ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }

        public async Task LoadData()
        {
            var funcion = new Ddetallecompra();
            this.ListViewSource = await funcion.MostrarDcompra(Client.Idcliente);
        }
       

     
    }
}
