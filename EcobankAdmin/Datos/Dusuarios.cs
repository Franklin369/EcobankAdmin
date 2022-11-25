using EcobankAdmin.Conexiones;
using EcobankAdmin.Modelo;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EcobankAdmin.Datos
{
   public class Dusuarios
    {
        public async Task<bool> ValidarCuenta(Musuarios parametros)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebapyFirebase));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(parametros.correo, parametros.pass);
                var serializartoken = JsonConvert.SerializeObject(auth);
                Preferences.Set("MyFirebaseRefreshToken", serializartoken);
                return  true;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Datos incorrectos", "OK");
                return false;

            }

        }
    }
}
