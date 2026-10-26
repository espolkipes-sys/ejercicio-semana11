using ejercicio_semana11;
using System;
using System.IO;
internal class Program

{

    static int max_estudiantes = 40;
    static int max_cursos = 4;
    static string[] nombreCursos = { "Matemáticas: ", "Programación: ", "Fisica: ", "Base de datos: " };
    static string[] estudiante = new string[max_estudiantes];
    static double[,] matrizNotas = new double[max_estudiantes, max_cursos];
    static int total_estudiantes = 0;
    static string rutaArchivo = "notas_curso.txt";
    public static void RegistrarEstudiante()
    {
        Console.WriteLine("REGISTRO DE ESTUDIANTE");
        if (total_estudiantes >= max_estudiantes)
        {
            Console.WriteLine("Se alcanzo la capacidad maxima");
            return;
        }
        string nombre = validador.LeerTexto("Ingresar nombres y apellidos: ").ToUpper();
        estudiante[total_estudiantes] = nombre;
        Console.WriteLine("Ingresar las notas de 0 a 20: ");
        for (int i = 0; i < max_cursos; i++)
        {
            matrizNotas[total_estudiantes, i] = validador.LeerDecimales($"Ingresar nota de {nombreCursos[i]}");
        }
        total_estudiantes++;
        Console.WriteLine("Estudiante registrado..!");
    }
    public static void guardarArchivo()
    {
       Console.WriteLine("Guadar registros en archivos");

        if (total_estudiantes == 0)
        {
            Console.WriteLine("Sin registros a guardar");
            return;
        }
        using (StreamWriter escritor = new StreamWriter(rutaArchivo))
        {
            for (int i = 0; i < total_estudiantes; i++)
            {
                string linea = estudiante[i];
                for (int j = 0; j < max_cursos; j++)
                {
                    linea += "," + matrizNotas[i, j];
                }
                escritor.WriteLine(linea);
            }
        }
        Console.WriteLine("Registros guardados...!!");
    }
   public static void CargarRegistro()
    {
        Console.WriteLine("CARGAR REGISTROS DESDE ARCHIVO");
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("No existe el archivo");
            return;
        }
        total_estudiantes = 0;
        using (StreamReader lector = new StreamReader(rutaArchivo))
        {
            string linea;
            while ((linea = lector.ReadLine()) != null && total_estudiantes < max_estudiantes)
            {
                string[] partes = linea.Split(',');
                if (partes.Length == max_cursos + 1)
                {
                    estudiante[total_estudiantes] = partes[0];
                    for (int i = 0; i < max_cursos; i++)
                    {
                        matrizNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                    }
                    total_estudiantes++;
                }
            }
        }
        Console.WriteLine("Se cargaron los registros del archivo...!!!");
    }
    public static void mostraRegistros()
    {
        Console.WriteLine(new string('=', 100));
        Console.WriteLine("\t\t REGISTRO GENERAL DE NOTAS POR CURSO");
        Console.WriteLine(new string('=', 100));
        if (total_estudiantes == 0)
        {
            Console.WriteLine("No existe Registros...!!!");
            return;
        }
        Console.Write($"{"ESTUDIANTE",-25}|");
        for (int i = 0; i < max_cursos; i++)
        {
            Console.Write($"{nombreCursos[i],-12}");
        }
        Console.WriteLine("PROMEDIO");
        Console.WriteLine(new string('-', 100));
        for (int i = 0; i < total_estudiantes; i++)
        {
            Console.Write($"{estudiante[i],-25}|");
            double suma = 0;
            for (int j = 0; j < max_cursos; j++)
            {
                Console.Write($"{matrizNotas[i, j],-12:F1}|");
                suma += matrizNotas[i, j];
            }
            double promedio = suma / max_cursos;
            string estado = promedio >= 12 ? "Apobado" : "Desapobrado";
            Console.WriteLine($"{promedio:F2}({estado})");
        }
    }
    static void Main(string[] args)
    {
        int opc = 0;
        while (opc != 5)
        {
            Console.Clear();
            Console.WriteLine("[1] REGRISTRAR ESTUDIANTE");
            Console.WriteLine("[2] GUARDAS EN ARCHIVO");
            Console.WriteLine("[3] CARGAR REGISTROS EL ARCHIVO");
            Console.WriteLine("[4] MOSTRAR REGISTROS ");
            Console.WriteLine("[5] SALIR ");
            opc = validador.LeerEntero("Seleccionar opción [1-5]: ");
            switch (opc)
            {
                case 1:
                    RegistrarEstudiante(); break;
                case 2:
                    guardarArchivo(); break;
                case 3:
                    CargarRegistro(); break;
                case 4:
                    mostraRegistros(); break;
                case 5:
                    Console.WriteLine("Muchos exitos para el nuevo semestre"); break;
            }
            Console.ReadKey();
        }
    }
}

