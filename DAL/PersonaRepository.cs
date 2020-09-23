using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonaRepository
    {

        private string fileName = @"Persona.txt";

        public void Guardar(Persona persona)
        {

            FileStream file = new FileStream(fileName,FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Sexo};{persona.Pulsacion}");
            writer.Close();
            file.Close();

        }

        public List<Persona> Consultar()
        {
            List<Persona> personas = new List<Persona>();

            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            reader.ReadLine();

            string linea = reader.ReadLine();
            while ((linea = reader.ReadLine())!=null)
            {

                char delimiter = ';';
                string[] DatosPersona = linea.Split(delimiter);
                Persona persona = new Persona();
                persona.Identificacion = DatosPersona[0];
                persona.Nombre = DatosPersona[1];
                persona.Edad = Convert.ToInt32(DatosPersona[2]);
                persona.Sexo = DatosPersona[3];
                persona.Pulsacion = Convert.ToDecimal(DatosPersona[4]);
                personas.Add(persona);

            }

            file.Close();
            reader.Close();
            return personas;

        }

    }
}
