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


                Persona persona = new Persona(identificacion, nombre, edad, sexo);
                persona.Pulsacion = personaService.CalcularPulsacion(sexo, edad);

                Console.WriteLine("\t\t\t\t_[RESULTADO]_ ");
                Console.WriteLine("\t\t\n"+persona.Nombre);
                Console.WriteLine("\t\n Su Pulsacion es :" + persona.Pulsacion);
                Console.WriteLine($"\n\nOperacion :{personaService.guardar(persona)}");
                Console.ReadKey();

                Console.WriteLine("\t\t\t\t\n\nSi desea Continuar Presione la tecla [_S_]");
                Console.WriteLine("\t\t\t\t\n\nPresione cualquier tecla para Salir [__]");
                seguir = Console.ReadLine();
                Console.Clear();


            } while (seguir.ToUpper().Equals("S"));

        }
    }
}
