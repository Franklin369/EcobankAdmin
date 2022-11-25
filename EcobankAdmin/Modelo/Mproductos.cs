using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EcobankAdmin.Modelo
{
    public class Mproductos
    {
        public string Descripcion { get; set; }
        public string Precioventa { get; set; }
        public string PreciocompraString { get; set; }

        public string Preciocompra { get; set; }
        public string Und { get; set; }
        public string Idproducto { get; set; }
        public string Color { get; set; }
        public string Icono { get; set; }
        public Color BackgroundColor { get; set; }
        public string Estado { get; set; }
        public string VisibleEstado { get; set; }
        public string VisibleElimEdit { get; set; }
        public string Colorletraestado { get; set; }

    }
}
