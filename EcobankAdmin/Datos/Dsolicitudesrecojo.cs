using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcobankAdmin.Modelo;
using EcobankAdmin.Conexiones;
using EcobankAdmin.VistaModelo;

namespace EcobankAdmin.Datos
{
    public class Dsolicitudesrecojo
    {
        public async Task InsertarSolicitud(Msolicitudesrecojo parametros)
        {
            await Constantes.firebase
                    .Child("Solicitudesrecojo")
                    .PostAsync(new Msolicitudesrecojo()
                    {
                        Estado = parametros.Estado,
                        Fecha = parametros.Fecha,
                        Idcliente = parametros.Idcliente,
                        Idturno = parametros.Idturno
                    });
        }
        public async Task<List<Msolicitudesrecojo>> MostrarsolicitRecojo()
        {
           


            var lista = new List<Msolicitudesrecojo>();
            var data = (await Constantes.firebase
              .Child("Solicitudesrecojo")
              .OnceAsync<Msolicitudesrecojo>()).Where(a => a.Object.Estado != "Asignado").Where(b => b.Key != "Modelo");

            foreach (var item in data)
            {
                var parametros = new Msolicitudesrecojo();
                parametros.Idsolicitud = item.Key;
                parametros.Idcliente = item.Object.Idcliente;
                parametros.Idturno = item.Object.Idturno;
                var fcliente = new Dclientes();
                var pcliente = new Mclientes();
                pcliente.Idcliente = parametros.Idcliente;
                var listcliente = await fcliente.MostrarclientesXid(pcliente);
               
                    pcliente.IdPais = listcliente[0].IdPais;
                    pcliente.IdDepa = listcliente[0].IdDepa;
                    pcliente.IdPro = listcliente[0].IdPro;
                    pcliente.IdDis = listcliente[0].IdDis;
                    pcliente.IdZona = listcliente[0].IdZona;

                    var fubicaciones = new Dubicaciones();
                    var ppais = new Mubicaciones();
                    var pubicaciones = new Mubicaciones();
                    var pais = await fubicaciones.MostrarpaisXid(pcliente);
                    var depa = await fubicaciones.MostrardepartamentoXid(pcliente);
                    var prov = await fubicaciones.MostrarProvinciaXid(pcliente);
                    var dist = await fubicaciones.MostrardistritoXid(pcliente);
                    var zona = await fubicaciones.MostrarZonaXid(pcliente);
                    parametros.ubicacioncompleta = pais + "-" + depa + "-" + prov + "-" + dist + "-" + zona;
                    parametros.Nombrecliente = listcliente[0].NombresApe;
                    var fturnos = new Dturnosrecojos();
                    var turno = await fturnos.MostrarturnosrecojoXid(parametros);
                    parametros.turno = turno;

                
                lista.Add(parametros);


            }
            return lista;

        }
        public async Task Asignarsolicitud(Msolicitudesrecojo parametrospedir)
        {
            var data = (await Constantes.firebase
              .Child("Solicitudesrecojo")
              .OnceAsync<Msolicitudesrecojo>()).Where(a => a.Key == parametrospedir.Idsolicitud).FirstOrDefault();

            data.Object.Estado = "Asignado";
            await Constantes.firebase
              .Child("Solicitudesrecojo")
              .Child(data.Key)
              .PutAsync(data.Object);

        }
    }
}
