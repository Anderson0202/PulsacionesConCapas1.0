using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaService
    {

        public decimal CalcularPulsacion(String sexo, int edad)
        {

            if (sexo.ToUpper().Equals("F"))
            {

                return 220 - edad / 10;

            }
            else if (sexo.ToUpper().Equals("M"))
            {
                return 210 - edad / 10;
            }
            else
            {
            return 0;
            }

            
        }

    }
}
