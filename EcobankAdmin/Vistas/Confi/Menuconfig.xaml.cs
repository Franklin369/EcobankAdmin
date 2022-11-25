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
    public partial class Menuconfig : ContentPage
    {
        public Menuconfig()
        {
            InitializeComponent();
            BindingContext = new VMmenuconfig(Navigation);
        }
    }
}