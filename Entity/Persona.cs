using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public String Identificacion { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public String Sexo { get; set; }
        public decimal Pulsacion { get; set; }

        public Persona(string identificacion, string nombre, int edad, string sexo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
        }

        public Persona()
        {
        }

    }
}
