using System;
using System.Collections.Generic;
using System.Text;

namespace EcobankAdmin.Modelo
{
   public class Msolicitudesrecojo
    {
        public string Idsolicitud { get; set; }
        public string Fecha { get; set; }
        public string Idcliente { get; set; }
        public string Idturno { get; set; }
        public string Estado { get; set; }
        //
        public string Nombrecliente { get; set; }
        public string ubicacioncompleta { get; set; }
        public string total { get; set; }
        public string turno { get; set; }
        public bool IsBusy { get; set; }

    }
}
