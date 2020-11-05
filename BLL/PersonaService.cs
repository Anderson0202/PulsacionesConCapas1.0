using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;

        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public decimal CalcularPulsacion(String sexo, int edad)
        {
        
            if (sexo.ToUpper().Equals("F"))
            {
            
                return (220 - edad) / 10;
            
            }
            else if (sexo.ToUpper().Equals("M"))
            {
                return (210 - edad) / 10;
            }
            else
            {
                return 0;
            }
        
        }


        public string guardar(Persona persona) 
        {

            try
            {
                if (personaRepository.BuscarRtry(persona.Identificacion)==null)
                {

                    personaRepository.Guardar(persona);
                    return " Guardamos su registro y pulsacion Exitosamente [_ n_n _]";

                }
                else
                {
                    return "*Atencion* La Identificacion [" + persona.Identificacion + "] ha sido registrada anteriormente";
                }
            }
            catch (Exception exception)
            {

                return " Error de la aplicacion : " + exception.Message;
            }
            
        }

        public void Eliminar(Persona persona)
        {

        }
        
        public PersonaResponse BuscarConIdentificacion(String identificacion)
        {

            PersonaResponse personaResponse;

            try
            {

                Persona persona = personaRepository.BuscarRtry(identificacion);
                if (persona!= null)
                {
                    return personaResponse = new PersonaResponse(persona);
                }
                else
                {
                    return personaResponse = new PersonaResponse("No esta Almacenada esta Persona");
                }

            }
            catch (Exception e)
            {

                return personaResponse = new PersonaResponse("Error de Aplicacion :" + e.Message);
            }

        }

    }


    public class PersonaResponse
    {

        public Persona Persona { get; set; }
        public string Message { get; set; }
        public bool PersonaEncontrada { get; set; }

        public PersonaResponse(Persona persona)
        {

            Persona = new Persona();
            Persona = persona;
            PersonaEncontrada = true;

        }

        public PersonaResponse(string message)
        {

            Message = message;
            PersonaEncontrada = false;

        }
        
    }

    public class ConsultaPersonaResponse
    {

        public List<Persona> Personas { get; set; }
        public string Message { get; set; }
        public bool PersonaEncontrada { get; set; }

        public ConsultaPersonaResponse(List<Persona> personas)
        {
            Personas = new List<Persona>();
            Personas = personas;
            PersonaEncontrada = true;
        }
        public ConsultaPersonaResponse(string message)
        {

            Message = message;
            PersonaEncontrada = false;

        }
    }

}
