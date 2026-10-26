using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_semana11
{
    internal class validador
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 1 || valor > 5)
                    {
                        Console.WriteLine("Error: El valor debe estar entre 1 y 5");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: Debe ingresar un número entero válido.");

            }
        }
        public static double LeerDecimales(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.WriteLine(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("Error la nota es entre 0 y 20");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: El valor debe ser numerico decimal");
            }
        }
        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.WriteLine(mensaje);
                string texto = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(texto))
                    return texto;
                Console.WriteLine("Error este campo no puede estar vacio ");
            }
        }
    }
}