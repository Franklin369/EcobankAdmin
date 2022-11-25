using EcobankAdmin.Modelo;
using EcobankAdmin.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobankAdmin.Vistas.Compras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PruebaCarrosel : ContentPage
    {
        public PruebaCarrosel()
        {
            InitializeComponent();
            Mostrarproductos();
        }
        List<Mproductos> dt = new List<Mproductos>();
        string color;
        async Task Mostrarproductos()
        {
            //var funcion = new VMagregarproductos();
            //dt = await funcion.MostrarProductos();
            //Carousel.ItemsSource = dt;
        }
        private void CarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            var carousel = sender as CarouselView;
            var views = carousel.VisibleViews;
            //color = ((CarouselView)sender).AutomationId.ToString();
            if (views.Count > 0)
            {
                foreach (var view in views)
                {
                    
                    var img = view.FindByName<Image>("MenuImg");
                    var grid = view.FindByName<Grid>("Gridcontenedor");
                    var framegeneral = view.FindByName<Frame>("FrameGeneral");
                    var gradiente1 = view.FindByName<GradientStop>("Gra1");

                    gradiente1.Color= Color.FromHex(grid.AutomationId);
                    //framegeneral.ScaleTo(0.1, 250);
                    //grid.BackgroundColor = Color.FromHex(grid.AutomationId);
                    ViewExtensions.CancelAnimations(img);
                    Task.Run(async () => await img.RelRotateTo(360, 5000, Easing.BounceOut));
                }
            }
        }

        private void btnagregar_Clicked(object sender, EventArgs e)
        {

        }
        //protected override async void OnAppearing()
        //{

        //    base.OnAppearing();
        //    await Task.Delay(2000);
        //    await Task.WhenAll(
        //        SplashGrid.FadeTo(0,2000),
        //        Logo.ScaleTo(0,2000)
        //        );
        //}
    }
}