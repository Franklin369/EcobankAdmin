using EcobankAdmin.Conexiones;
using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace EcobankAdmin.VistaModelo
{
    public class VMagregarasignacion : BaseViewModel
    {
        #region variables


        public List<Mubicaciones> listpais = new List<Mubicaciones>();
        public List<Mubicaciones> listdepa = new List<Mubicaciones>();
        public List<Mubicaciones> listprov = new List<Mubicaciones>();
        public List<Mubicaciones> listdist = new List<Mubicaciones>();
        public List<Mubicaciones> listzona = new List<Mubicaciones>();
        Mubicaciones selectPais;
        Mubicaciones selectDepa;
        Mubicaciones selectProv;
        Mubicaciones selectDist;
        Mubicaciones selectZona;
        private string Idpais;
        private string Iddepa;
        private string Idprov;
        private string Iddist;
        private string Idzona;


        public object listaasignaciones;
        public object listarecolectores;
        public string idrecolector;
        public string idasignacion;
        public string nombrerecolector;
        public static bool ActivarEdicion;
        public Msolicitudesrecojo Solicitudes { get; set; }
        public bool estadosedicionPass;
        public string identificacion;
        #endregion
        #region Constructor
        public VMagregarasignacion(INavigation navigation, Msolicitudesrecojo solicitudes)
        {
            Navigation = navigation;
            Insertarcommad = new Command(async () => await Insertarasignaciones());
            Volvercomman = new Command(async (param) => await Volver());
            Buscarcommand = new Command(async () => await buscarRecolectores());
            Solicitudes = solicitudes;
            Mostrarpais();
            MostrarDepa();
            MostrarDist();
            MostrarProv();
            MostrarZonas();
        }

        #endregion
        #region Objetos
        public bool EstadoVisPass
        {
            get
            {
                return estadosedicionPass;
            }
            set
            {
                SetProperty(ref estadosedicionPass, value);
            }
        }

        public string txtIdentificacionRecolec
        {
            get
            {
                return identificacion;
            }
            set
            {
                SetProperty(ref identificacion, value);
            }
        }
        public string txtNombrerecolector
        {
            get
            {
                return nombrerecolector;
            }
            set
            {
                SetProperty(ref nombrerecolector, value);
            }
        }

        public object Listaasignaciones
        {
            get
            {
                return listaasignaciones;
            }
            set
            {
                SetProperty(ref listaasignaciones, value);
            }
        }
        public string txtIdentificacion
        {
            get
            {
                return identificacion;
            }
            set
            {
                SetProperty(ref identificacion, value);
            }
        }
        public string txtIdrecolector
        {
            get
            {
                return idrecolector;
            }
            set
            {
                SetProperty(ref idrecolector, value);
            }
        }
        public Mubicaciones SelectPais
        {
            get { return selectPais; }
            set
            {
                SetProperty(ref selectPais, value);
                Idpais = selectPais.Idpais;

            }
        }
        public Mubicaciones SelectDepa
        {
            get { return selectDepa; }
            set
            {
                SetProperty(ref selectDepa, value);
                Iddepa = selectDepa.Iddepartamento;

            }
        }
        public Mubicaciones SelectProv
        {
            get { return selectProv; }
            set
            {
                SetProperty(ref selectProv, value);
                Idprov = selectProv.Idprovincia;

            }
        }
        public Mubicaciones SelectDist
        {
            get { return selectDist; }
            set
            {
                SetProperty(ref selectDist, value);
                Iddist = selectDist.Iddistrito;

            }
        }
        public Mubicaciones SelectZona
        {
            get { return selectZona; }
            set
            {
                SetProperty(ref selectZona, value);
                Idzona = selectZona.Idzona;

            }
        }
        public List<Mubicaciones> Listpais
        {
            get { return this.listpais; }
            set
            {
                SetValue(ref this.listpais, value);
            }
        }
        public List<Mubicaciones> ListDepa
        {
            get { return this.listdepa; }
            set
            {
                SetValue(ref this.listdepa, value);
            }
        }
        public List<Mubicaciones> ListProv
        {
            get { return this.listprov; }
            set
            {
                SetValue(ref this.listprov, value);
            }
        }
        public List<Mubicaciones> ListDistr
        {
            get { return this.listdist; }
            set
            {
                SetValue(ref this.listdist, value);
            }
        }
        public List<Mubicaciones> ListZona
        {
            get { return this.listzona; }
            set
            {
                SetValue(ref this.listzona, value);
            }
        }
        #endregion
        #region procesos
        private async Task Insertarasignaciones()
        {
            if (!string.IsNullOrEmpty(txtIdentificacion))
            {
                var funcion = new Dasignaciones();
                var parametros = new Masignaciones();
                parametros.idrecolector = txtIdrecolector;
                parametros.idsolicitud = Solicitudes.Idsolicitud;
                parametros.estado = "Pendiente";

                var estado = await funcion.Insertarasignaciones(parametros);
                if (estado == true)
                {
                    await AsignarSolicitudes();
                    await DisplayAlert("Hecho", "Asignación realizada", "OK");
                    await Volver();
                }
            }
            else
            {
                await DisplayAlert("Sin datos", "Asigne un recolector", "OK");
            }

        }
        private async Task AsignarSolicitudes()
        {

            var funcion = new Dsolicitudesrecojo();
            var parametros = new Msolicitudesrecojo();
            parametros.Idsolicitud = Solicitudes.Idsolicitud;
            await funcion.Asignarsolicitud(parametros);
        }


        private async Task buscarRecolectores()
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Identificacion = txtIdentificacionRecolec;
            var list = await funcion.BuscarRecolectores(parametros);
            foreach (var data in list)
            {
                txtNombrerecolector = data.Nombre;
                txtIdrecolector = data.Idrecolectores;
            }
        }
        public async Task CrearCorreo(string correo, string contraseña)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebapyFirebase));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, contraseña);
            await DisplayAlert("Perfecto", "Registro guardado", "OK");
            await Navigation.PopAsync();
        }
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public async Task Mostrarpais()
        {
            var funcion = new Dubicaciones();
            this.Listpais = await funcion.Mostrarpais();
        }
        public async Task MostrarDepa()
        {
            var funcion = new Dubicaciones();
            this.ListDepa = await funcion.Mostrardepartamento();
        }
        public async Task MostrarProv()
        {
            var funcion = new Dubicaciones();
            this.ListProv = await funcion.MostrarProvincia();
        }
        public async Task MostrarDist()
        {
            var funcion = new Dubicaciones();
            this.ListDistr = await funcion.Mostrardistrito();
        }
        public async Task MostrarZonas()
        {
            var funcion = new Dubicaciones();
            this.ListZona = await funcion.MostrarZona();
        }
        #endregion

        #region comandos
        public Command Buscarcommand { get; set; }
        public Command Insertarcommad { get; set; }
        public Command Editarcommand { get; set; }
        public Command Volvercomman { get; }
        #endregion
    }
}
