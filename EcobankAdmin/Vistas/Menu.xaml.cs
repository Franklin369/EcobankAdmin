using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcobankAdmin.Modelo;
using EcobankAdmin.VistaModelo;
namespace EcobankAdmin.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
       
        public Menu(Musuarios client)
        {
            InitializeComponent();
          
            BindingContext = new VMmenu(Navigation,client);

            //MostrarMovimientos();
        }

        private async void btnHoy_Clicked(object sender, EventArgs e)
        {
          //await  InsertarMovimiento();
          //  await MostrarMovimientos();
        }
        //private async Task MostrarMovimientos()
        //{
        //    var funcion = new VMmovimientos();
        //    var data = await funcion.MostrarMovimientos();
        //    ListaMovimientos.ItemsSource = data;
        //}
        //private async Task InsertarMovimiento()
        //{
        //    var funcion = new VMmovimientos();
        //    var parametros = new Mmovimientos();
        //    parametros.Fecha = "29 mayo 2021";
        //    parametros.Idcategoria = "Botellas";
        //    parametros.Kg = "2,4 Kg";
        //    parametros.Movimiento = "Pago recibido";
        //    parametros.Total = "S/.5.00";
        //    await funcion.InsertarMovimientos(parametros);
        //}
    }
}