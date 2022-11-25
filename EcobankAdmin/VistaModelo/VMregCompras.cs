using EcobankAdmin;
using EcobankAdmin.Conexiones;
using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas.Compras;
using Firebase.Database.Query;
using GalaSoft.MvvmLight.Command;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
   public class VMregCompras : BaseViewModel
    {
       
        private VMagregarproductos services;
        public object listViewSource;
        private string Total;
        private string Cantidad;
        private string Ganancia;
        private string Preciocompra;
        public VMregCompras(INavigation navigation)
        {
            //services = new VMagregarproductos();

            Navigation = navigation;
            NavigateToDetailPageCommand = new Command<Mproductos>(async (param) => await ExeccuteNavigateToDetailPageCommand(param));
            AgregarDetallecompraCommand = new Command<Mdetallecompra>(async (Mdetallecompra) => await agregarDetallecompra(Mdetallecompra));
            LoadData();
        }
        #region Propertiers
        public string Cantidadtxt
        {
            get { return this.Cantidad; }
            set { SetValue(ref this.Cantidad, value); }
        }
        #endregion
        #region Commands
        public ICommand AgregarCommand
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
            if(!string.IsNullOrEmpty(Cantidadtxt))
            {
                double cant =Convert.ToDouble( Cantidadtxt);
                double preciocomp = Convert.ToDouble(Preciocompra);
                Total = (cant * preciocomp).ToString();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Ingrese un valor", "OK");
            }
        }
        #endregion
        public async Task agregarDetallecompra(Mdetallecompra parametros)
        {
            var funcion = new Ddetallecompra();
            await funcion.InsertarDetallecompra(parametros);
        }
        public Command NavigateToDetailPageCommand { get; }
        public Command SelectCategoryCommand { get; }
        public Command AgregarDetallecompraCommand { get; }

        //public ObservableCollection<Category> Categories { get; set; }

        private async Task ExeccuteNavigateToDetailPageCommand(Mproductos product)
        {
            var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            SharedTransitionNavigationPage.SetTransitionSelectedGroup(page, product.Idproducto);
            await Navigation.PushAsync(new Pagregarcompra(product));
        }
        private ObservableCollection<Mproductos> funcionProductos = new ObservableCollection<Mproductos>();
        public ObservableCollection<Mproductos>Productos
        {
            get { return funcionProductos; }
            set
            {
                funcionProductos = value;
                OnPropertyChanged();
            }
           
        }
        public async Task LoadData()
        {
            //var funcion = new VMagregarproductos();
            //this.ListViewSource = await funcion.MostrarProductos2();
        }
        public object ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
      
        //public async Task<List<Mproductos>> MostrarProductos()
        //{
        //    //var Movimientos = new List<Mproductos>();
        //    var data = (await Constantes.firebase
        //        .Child("Productos")
        //        .OrderByKey()
        //        .OnceAsync<Mproductos>());
        //    foreach (var dt in data)
        //    {
        //        var parametros = new Mproductos();
        //        parametros.Descripcion = dt.Object.Descripcion;
        //        parametros.Preciocompra = "S/. " + dt.Object.Preciocompra + " x Kg";
        //        parametros.Precioventa = dt.Object.Precioventa;
        //        parametros.Und = dt.Object.Und;
        //        parametros.Idproducto = dt.Key;
        //        parametros.Color = dt.Object.Color;
        //        parametros.Icono = dt.Object.Icono;
        //        Products.Add(parametros);
        //    }
        //    return Products;
        //}
    }
}
