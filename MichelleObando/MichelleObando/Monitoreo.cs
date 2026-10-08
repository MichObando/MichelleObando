using System;

class Monitoreo
{
    const int NumeroRegistros = 19;
    static string[] nombrePaciente = new string[NumeroRegistros];
    static int[] gravedadPaciente = new int[NumeroRegistros];
    static int cantidadPacientes = 0;

    static void Main()
    {
        menu();
    }

    static void menu()
    {
        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("      HOSPITAL SAN RAFAEL");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("1. Ingresar paciente");
            Console.WriteLine("2. Consultar pacientes");
            Console.WriteLine("3. Modificar gravedad");
            Console.WriteLine("4. Eliminar paciente");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.Write("Ingrese una opcion (1-5): ");

            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    AgregarPaciente();
                    break;

                case 2:
                    ConsultarPacientes();
                    break;

                case 3:
                    ModificarGravedad();
                    break;

                case 4:
                    EliminarPaciente();
                    break;

                case 5:
                    Console.WriteLine("Un momento, saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta");
                    break;
            }

            if (opcion != 5)
            {
                Console.WriteLine();
                Console.WriteLine("Presione para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 5);
    }

    static void AgregarPaciente()
    {
        if (cantidadPacientes >= NumeroRegistros)
        {
            Console.WriteLine("No hay espacio para ingresar mas pacientes");
        }
        else
        {
            Console.WriteLine("=================================");
            Console.WriteLine("      INGRESAR PACIENTE");
            Console.WriteLine("=================================");
            Console.WriteLine("Ingrese el nombre del paciente:");
            string nuevoNombre = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Nivel de urgencia:");
            Console.WriteLine("1. Nivel 1 - Leve");
            Console.WriteLine("2. Nivel 2 - Normal");
            Console.WriteLine("3. Nivel 3 - Medio");
            Console.WriteLine("4. Nivel 4 - Grave");
            Console.WriteLine("5. Nivel 5 - Urgencia");
            Console.WriteLine("=================================");

            Console.WriteLine();
            Console.WriteLine("Ingrese el nivel de urgencia:");
            int nuevaGravedad = int.Parse(Console.ReadLine());

            if (!string.IsNullOrEmpty(nuevoNombre) &&
                nuevaGravedad >= 1 &&
                nuevaGravedad <= 5)
            {
                nombrePaciente[cantidadPacientes] = nuevoNombre;
                gravedadPaciente[cantidadPacientes] = nuevaGravedad;
                cantidadPacientes++;

                Console.WriteLine();
                Console.WriteLine("Paciente registrado correctamente");
                Console.WriteLine("=================================");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Datos incorrectos");
            }
        }
    }

    static void ConsultarPacientes()
    {
        if (cantidadPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados");
        }
        else
        {
            Console.WriteLine("=================================");
            Console.WriteLine("      LISTA DE PACIENTES");
            Console.WriteLine("=================================");
            Console.WriteLine();

            for (int pacientes = 0; pacientes < cantidadPacientes; pacientes++)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Paciente: " + nombrePaciente[pacientes]);
                Console.WriteLine("Nivel de urgencia: " + gravedadPaciente[pacientes]);
                Console.WriteLine("----------------------------------");
            }
        }
    }

    static void ModificarGravedad()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("      MODIFICAR GRAVEDAD");
        Console.WriteLine("=================================");
        Console.WriteLine("Ingrese el nombre del paciente:");
        string nombre = Console.ReadLine();

        for (int pacientes = 0; pacientes < cantidadPacientes; pacientes++)
        {
            if (nombre == nombrePaciente[pacientes])
            {
                Console.WriteLine();
                Console.WriteLine("Paciente encontrado.");
                Console.WriteLine("Nivel actual: " + gravedadPaciente[pacientes]);

                Console.WriteLine();
                Console.WriteLine("============================================");
                Console.WriteLine("Ingrese el nuevo nivel de urgencia (1-5):");
                Console.WriteLine("-------------------------------------------");
                int nuevaGravedad = int.Parse(Console.ReadLine());

                if (nuevaGravedad >= 1 && nuevaGravedad <= 5)
                {
                    gravedadPaciente[pacientes] = nuevaGravedad;

                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Gravedad modificada correctamente");
                    Console.WriteLine("========================================");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Nivel de urgencia incorrecto");
                }
                return;
            }
        }

        Console.WriteLine();
        Console.WriteLine("El paciente no se encuentra registrado");
    }

    static void EliminarPaciente()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("       ELIMINAR PACIENTE");
        Console.WriteLine("=================================");

        Console.WriteLine("Ingrese el nombre del paciente:");
        string nombre = Console.ReadLine();

        for (int pacientes = 0; pacientes < cantidadPacientes; pacientes++)
        {
            if (nombre == nombrePaciente[pacientes])
            {
                for (int modificaciones = pacientes; modificaciones < cantidadPacientes - 1; modificaciones++)
                {
                    nombrePaciente[modificaciones] = nombrePaciente[modificaciones + 1];
                    gravedadPaciente[modificaciones] = gravedadPaciente[modificaciones + 1];
                }

                nombrePaciente[cantidadPacientes - 1] = string.Empty;
                gravedadPaciente[cantidadPacientes - 1] = 0;
                cantidadPacientes--;

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Paciente eliminado correctamente");
                Console.WriteLine("-------------------------------------------");
                return;
            }
        }

        Console.WriteLine();
        Console.WriteLine("El paciente no se encuentra registrado");
    }
}