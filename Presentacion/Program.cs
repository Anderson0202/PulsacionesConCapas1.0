using BLL;
using Entity;
using System;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            String seguir;
            do
            {

                Console.WriteLine("\t\t\t   Bienvenid@");
                Console.WriteLine("\t\t Tome Su pulsacion ");
                Console.WriteLine("\tRegistre sus dastos personales a continuacion: ");
                Console.WriteLine("\nNumero de Identificacion:");
                String identificacion = Console.ReadLine();
                Console.WriteLine("\nNombre:");
                String nombre = Console.ReadLine();
                Console.WriteLine("\nEdad:");
                int edad = Convert.ToInt32(Console.ReadLine());

                PersonaService personaService = new PersonaService();
                String sexo;
                do
                {

                    Console.WriteLine("\nSexo: ");
                    Console.WriteLine("*Presione [_F_] -> Femenino");
                    Console.WriteLine("*Presione [_M_] -> Masculino");
                    sexo = Console.ReadLine();
                    Console.Clear();

                } while (personaService.CalcularPulsacion(sexo, edad) == 0);

                decimal pulsacion = personaService.CalcularPulsacion(sexo, edad);

                Persona persona = new Persona(identificacion, nombre, edad, sexo, pulsacion);

                Console.WriteLine("\t\t\t\tResultado de su pulsacion");
                Console.WriteLine("Pulacion :" + persona.Pulsacion);
                Console.ReadKey();

                Console.WriteLine("\t\t\t\t\nSi desea Continuar Presione la tecla [_S_]");
                Console.WriteLine("\t\t\t\t\n\nPresione cualquier tecla para Salir [__]");
                seguir = Console.ReadLine();
                Console.Clear();

            } while (seguir.ToUpper().Equals("S"));

        }
    }
}
