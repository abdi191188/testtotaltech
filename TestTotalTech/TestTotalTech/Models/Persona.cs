using System;
using System.Collections.Generic;
using System.Text;

namespace TestTotalTech.Models
{
    public class Persona
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public double rating { get; set; }

        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }

        public double latitud { get; set; }
        public double longitud { get; set; }


    }
}
