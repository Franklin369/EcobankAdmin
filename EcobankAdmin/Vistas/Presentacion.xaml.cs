using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobankAdmin.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Presentacion : ContentPage
    {
        public static string user;
        public Presentacion()
        {
            InitializeComponent();
            lblusuario.Text = user;
        }
    }
}