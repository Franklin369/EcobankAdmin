using EcobankAdmin.Modelo;
using EcobankAdmin.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobankAdmin.Vistas.Confi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarProducto : ContentPage
    {
        public AgregarProducto(Mproductos productos)
        {
            InitializeComponent();
            BindingContext = new VMagregarproductos(Navigation,productos);
        }
    }
}