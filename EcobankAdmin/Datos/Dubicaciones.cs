using EcobankAdmin.Conexiones;
using EcobankAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcobankAdmin.Datos
{
    public class Dubicaciones
    {
        public async Task<List<Mubicaciones>> Mostrarpais()
        {
            return (await Constantes.firebase
              .Child("Pais")
              .OnceAsync<Mubicaciones>()).Select(item => new Mubicaciones
              {
                  Idpais = item.Key,
                  Pais = item.Object.Pais
              }).ToList();
        }
        public async Task<List<Mubicaciones>> Mostrardepartamento()
        {
            return (await Constantes.firebase
              .Child("Departamento")
              .OnceAsync<Mubicaciones>()).Select(item => new Mubicaciones
              {
                  Iddepartamento = item.Key,
                  Departamento = item.Object.Departamento
              }).ToList();
        }
        public async Task<List<Mubicaciones>> MostrarProvincia()
        {
            return (await Constantes.firebase
              .Child("Provincia")
              .OnceAsync<Mubicaciones>()).Select(item => new Mubicaciones
              {
                  Idprovincia = item.Key,
                  Provincia = item.Object.Provincia
              }).ToList();
        }
        public async Task<List<Mubicaciones>> Mostrardistrito()
        {
            return (await Constantes.firebase
              .Child("Distrito")
              .OnceAsync<Mubicaciones>()).Select(item => new Mubicaciones
              {
                  Iddistrito = item.Key,
                  Distrito = item.Object.Distrito
              }).ToList();
        }
        public async Task<List<Mubicaciones>> MostrarZona()
        {
            return (await Constantes.firebase
              .Child("Zona")
              .OnceAsync<Mubicaciones>()).Select(item => new Mubicaciones
              {
                  Idzona = item.Key,
                  Zona = item.Object.Zona
              }).ToList();
        }

        #region porId
        public async Task<string> MostrarpaisXid(Mclientes parametros)
        {
            string pais;
            var data = (await Constantes.firebase
               .Child("Pais")
               .OnceAsync<Mubicaciones>()).Where(a => a.Key == parametros.IdPais).FirstOrDefault();
            return pais= data.Object.Pais;
        }
        public async Task<string> MostrardepartamentoXid(Mclientes parametros)
        {
            var data = (await Constantes.firebase
               .Child("Departamento")
               .OnceAsync<Mubicaciones>()).Where(a => a.Key == parametros.IdDepa).FirstOrDefault();
            return data.Object.Departamento;
        }
        public async Task<string> MostrarProvinciaXid(Mclientes parametros)
        {
            var data = (await Constantes.firebase
               .Child("Provincia")
               .OnceAsync<Mubicaciones>()).Where(a => a.Key == parametros.IdPro).FirstOrDefault();
            return data.Object.Provincia;
        }
        public async Task<string> MostrardistritoXid(Mclientes parametros)
        {
            var data = (await Constantes.firebase
               .Child("Distrito")
               .OnceAsync<Mubicaciones>()).Where(a => a.Key == parametros.IdDis).FirstOrDefault();
            return data.Object.Distrito;
        }
        public async Task<string> MostrarZonaXid(Mclientes parametros)
        {
            var data = (await Constantes.firebase
                .Child("Zona")
                .OnceAsync<Mubicaciones>()).Where(a => a.Key == parametros.IdZona).FirstOrDefault();
            return data.Object.Zona;
        }

        #endregion
    }
}
