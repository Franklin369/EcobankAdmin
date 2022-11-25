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
    public partial class Listarepart : ContentPage
    {
        public Listarepart()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            BindingContext = new VMlistarepart(Navigation);
        }
    }
}