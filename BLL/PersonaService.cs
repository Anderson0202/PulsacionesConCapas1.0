using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
                personaRepository.Guardar(persona);
                return " Guardamos un registro de su pulsacion";
            }
            catch (Exception exception)
            {

                return " Error de la aplicacion : " + exception.Message;
            }
            
        }

        public void Eliminar(Persona persona)
        {

        }

    }
}
