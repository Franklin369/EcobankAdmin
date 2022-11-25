using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using EcobankAdmin.Vistas;
using Plugin.SharedTransitions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
    public class VMsolicitarrecojo : BaseViewModel
    {
        public int contadorLogin;
        public bool solicitudhecha = false;
        public bool registroinicio = true;
        public string horaactual;
        public bool Solicitudhecha
        {
            get { return this.solicitudhecha; }
            set
            {
                SetValue(ref this.solicitudhecha, value);
            }
        }
        public string Horaactual
        {
            get { return this.horaactual; }
            set
            {
                SetValue(ref this.horaactual, value);
            }
        }
        public bool Registroinicio
        {
            get { return this.registroinicio; }
            set
            {
                SetValue(ref this.registroinicio, value);
            }
        }
        public List<Mturnosrecojo> listViewSource = new List<Mturnosrecojo>();
        Dturnosrecojos funcion = new Dturnosrecojos();

        public VMsolicitarrecojo(INavigation navigation, Mclientes client)
        {

            Navigation = navigation;
            Registroinicio = true;
            Solicitudhecha = false;
            Client = client;
            Horaactual = DateTime.Now.ToString("MM/dd/yyyy");
            string we = Horaactual;
            //var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
            //NavigationPage.SetHasNavigationBar(page, false);
            Volvercomman = new Command(async (param) => await Volver());
            AgregarSolicitudcomman = new Command<Msolicitudesrecojo>(async (param) => await EjecutarInsertarSolic(param));
            Mostrarturnosrecojo();
            //GetCategoriesAsync();
        }
        public Command Volvercomman { get; }

        private async Task Volver()
        {
            await PopupNavigation.Instance.PopAsync();
        }
        Mturnosrecojo selectTurno;
        public Mturnosrecojo SelectTurno
        {
            get { return selectTurno; }
            set
            {
                SetProperty(ref selectTurno, value);
                Turnotxt = selectTurno.Idturno;

            }
        }
        private string turno;
        public string Turnotxt
        {
            get
            {
                return turno;
            }
            set
            {
                SetProperty(ref turno, value);
            }
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public Command AgregarSolicitudcomman { get; }

        private async Task EjecutarInsertarSolic(Msolicitudesrecojo parametros)
        {
            await agregarSolicitud(parametros);
        }
        public Mclientes Client { get; set; }
        public List<Mturnosrecojo> ListViewSource
        {
            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        //public string Fechatxt
        //{
        //    get { return this.fecha; }
        //    set { SetValue(ref this.fecha, value); }
        //}
        bool _dateToPickerVisibility;
        DateTime _dateTo;

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime DateTo
        {
            get => _dateTo;
            set
            {
                _dateTo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTo)));
            }
        }

        public bool DateToPickerVisibility
        {
            get => _dateToPickerVisibility;
            set
            {
                _dateToPickerVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateToPickerVisibility)));
            }
        }

        public async Task Mostrarturnosrecojo()
        {
            var funcion = new Dturnosrecojos();
            this.ListViewSource = await funcion.Mostrarturnosrecojo();
        }
        public async Task agregarSolicitud(Msolicitudesrecojo parametros)
        {
            if(!string.IsNullOrEmpty( Turnotxt))
            {
                if(!string .IsNullOrEmpty(DateTo.ToString()))
                {
                    var funcion = new Dsolicitudesrecojo();
                    var parametrosS = new Msolicitudesrecojo();
                    parametrosS.Idcliente = Client.Idcliente;
                    parametrosS.Estado = "POR CONFIRMAR";
                    parametrosS.Fecha = DateTo.ToString("dd/MM/yyyy");
                    string ff = parametrosS.Fecha;
                    parametrosS.Idturno = Turnotxt;
                    await funcion.InsertarSolicitud(parametrosS);
                    Registroinicio = false;
                    Solicitudhecha = true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccione una fecha", "OK");

                }
            }
            else

            {
              await  Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccione un turno", "OK");
            }
            

            //await Application.Current.MainPage.DisplayAlert("Reg", "Listo", "OK");
        }
    }
}
