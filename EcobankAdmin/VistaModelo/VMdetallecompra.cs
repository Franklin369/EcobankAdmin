using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
    public class VMdetallecompra : BaseViewModel
    {
        private string Total;
        private string Cantidad;
        private double Ganancia;
        private double Precioventa;
        private string Preciocompra="2";

        public VMdetallecompra(INavigation navigation, Mproductos product)
        {
            Navigation = navigation;
            //DependencyService.Get<IStatusBarStyle>().ChangeTextColor(true);
            PopDetailPageCommand = new Command(async () => await ExecutePopDetailPageCommand());
            Product = product;
        }

        public Command PopDetailPageCommand { get; }
        public Mproductos Product { get; set; }

        private async Task ExecutePopDetailPageCommand()
        {
            CalcularTotal();
            await InsertarDetallecompra();
            await Navigation.PopAsync();

        }
        async Task InsertarDetallecompra()
        {
            var funcion = new Ddetallecompra();
            var parametros = new Mdetallecompra();
            parametros.Ganancia = Ganancia.ToString();
            parametros.Idcliente = "-";
            parametros.Idproducto = Product.Idproducto;
            parametros.Cantidad = Cantidadtxt;
            parametros.Preciocompra = Product.Preciocompra;
            parametros.PrecioVenta = Product.Precioventa;
            parametros.Total = Totaltxt;
            parametros.Und = Product.Und;
            parametros.Puntos = "-";
            await funcion.InsertarDetallecompra(parametros); 
        }
        #region Propertiers
        public string Cantidadtxt
        {
            get { return this.Cantidad; }
            set { SetValue(ref this.Cantidad, value); }
        }
        public string Totaltxt
        {
            get { return this.Total; }
            set { SetValue(ref this.Total, value); }
        }
        #endregion
        #region Commands
        public ICommand CalcularCommand
        {
            get
            {
                return new RelayCommand(CalcularTotal);
            }
            set
            {

            }
        }
        #endregion
        #region Metodos

        private void CalcularTotal()
        {
            if (!string.IsNullOrEmpty(Cantidadtxt))
            {
                double cant = Convert.ToDouble(Cantidadtxt);
                double preciocomp =Convert.ToDouble( Product.Preciocompra);
                Totaltxt = (cant * preciocomp).ToString();
                Ganancia = cant * Precioventa - cant * preciocomp;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Ingrese un valor", "OK");
            }
        }
        #endregion
    }
} 

