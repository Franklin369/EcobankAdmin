using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcobankAdmin.Modelo;
using EcobankAdmin.VistaModelo;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobankAdmin.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Solicitarrecojo : PopupPage
    {
        public Solicitarrecojo(Mclientes client)
        {
            InitializeComponent();
            BindingContext = new VMsolicitarrecojo(Navigation, client);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}