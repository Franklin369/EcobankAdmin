using EcobankAdmin.Conexiones;
using EcobankAdmin.Datos;
using EcobankAdmin.Modelo;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EcobankAdmin.VistaModelo
{
    public class VMagregarrecolect : BaseViewModel
    {
        #region variables
        public object listaRecolectores;
        public string nombre;
        public string identificacion;
        public string correo;
        public string pass;
        public static bool ActivarEdicion;
        public Mrecolectores Recolectores { get; set; }
        public bool estadosedicionPass;

        #endregion
        #region Constructor
        public VMagregarrecolect(INavigation navigation, Mrecolectores recolectores)
        {
            Navigation = navigation;
            InsertarRecoleccomman = new Command(async () => await AgregarRecolectores());
            Volvercomman = new Command(async (param) => await Volver());
            Recolectores = recolectores;
            Recuperardatos();
        }
        private void Recuperardatos()
        {
            if (ActivarEdicion==true)
            {
                txtNombre = Recolectores.Nombre;
                txtCorreo = Recolectores.Correo;
                txtIdentificacion = Recolectores.Identificacion;
                EstadoVisPass = false;
            }
            else
            {
                EstadoVisPass = true;
            }

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
        public string txtPass
        {
            get
            {
                return pass;
            }
            set
            {
                SetProperty(ref pass, value);
            }
        }
        public string txtNombre
        {
            get
            {
                return nombre;
            }
            set
            {
                SetProperty(ref nombre, value);
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
        public string txtCorreo
        {
            get
            {
                return correo;
            }
            set
            {
                SetProperty(ref correo, value);
            }
        }
        #endregion
        #region procesos
        private async Task AgregarRecolectores()
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Nombre = txtNombre;
            parametros.Identificacion = txtIdentificacion;
            parametros.Correo = txtCorreo;
            parametros.Estado = "Activo";
            var estado = await funcion.InsertarRecolectores(parametros);
            if (estado == true)
            {
                await CrearCorreo(txtCorreo, txtPass);

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
        #endregion

        #region comandos
        public Command InsertarRecoleccomman { get; set; }
        public Command EditarRecoleccomman { get; set; }
        public Command Volvercomman { get; }
        #endregion



    }
}
