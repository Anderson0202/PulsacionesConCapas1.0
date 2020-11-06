using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class PersonaRepository
    {

        private string fileName = @"Persona.txt";

        public void Guardar(Persona persona)
        {

            FileStream file = new FileStream(fileName, FileMode.Append);
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
            while ((linea = reader.ReadLine()) != null)
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

        public Persona BuscarRtry(String identificacion)
        {

            List<Persona> personas = ConsultarTodaLaLista();
            foreach (var item in personas)
            {

                if (SeEncuentra(item.Identificacion, identificacion))
                {
                    return item;
                }

            }
            return null;
        }

        private bool SeEncuentra(string identificacionAlmacenada, string identificacionBuscada)
        {

            return identificacionAlmacenada == identificacionBuscada;

        }

        public List<Persona> ConsultarTodaLaLista()
        {

            List<Persona> ListaDePersonas = new List<Persona>();
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            String linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Persona persona = Map(linea);
                ListaDePersonas.Add(persona);

            }

            reader.Close();
            file.Close();
            return ListaDePersonas;

        }

        private Persona Map(string linea)
        {

            Persona persona = new Persona();
            char delimiter = ';';
            string[] sacaMatrizPersona = linea.Split(delimiter);
            persona.Identificacion = sacaMatrizPersona[0];
            persona.Nombre = sacaMatrizPersona[1];
            persona.Edad = int.Parse(sacaMatrizPersona[2]);
            persona.Sexo = sacaMatrizPersona[3];
            persona.Pulsacion = int.Parse(sacaMatrizPersona[4]);

            return persona;

        }

        public void Eliminar(string identificacion)
        {

            List<Persona> ListaDePersonas = new List<Persona>();
            ListaDePersonas = ConsultarTodaLaLista();
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
            foreach (var item in ListaDePersonas)
            {
                if (!SeEncuentra(item.Identificacion, identificacion))
                {
                    Guardar(item);
                }
            }

        }

        public void Modificar(Persona personaVieja, Persona personaNueva)
        {
            List<Persona> ListaDePersonas = new List<Persona>();
            ListaDePersonas = ConsultarTodaLaLista();
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
            foreach (var item in ListaDePersonas)
            {
                if (!SeEncuentra(item.Identificacion, personaVieja.Identificacion))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNueva);
                }
            }

        }

        public List<Persona> FiltrarSexo(string sexo)
        {
            return ConsultarTodaLaLista().Where(prsn => prsn.Sexo.Equals(sexo)).ToList();
        }

        public List<Persona> FiltrarMasculino()
        {

            List<Persona> ListaDePersonas = ConsultarTodaLaLista();
            List<Persona> personasFiltradas =
                (from persona in ListaDePersonas
                 where persona.Sexo.Equals("M")
                 select persona).ToList();
            return personasFiltradas;
        }

       

        public List<Persona> FiltrarFemenino()
        {

            List<Persona> ListaDePersonas = ConsultarTodaLaLista();
            List<Persona> personasFiltradas =
                (from persona in ListaDePersonas
                 where persona.Sexo.Equals("F")
                 select persona).ToList();
            return personasFiltradas;
        }

        public int ContarSexo(string sexo)
        {
            return ConsultarTodaLaLista().Count(p => p.Sexo.Equals(sexo));
        }

        public List<Persona> FiltrarPorNombres(string nombre)
        {
            return ConsultarTodaLaLista().Where(prsn => prsn.Nombre.Contains(nombre)).ToList();
        }

    }
}
