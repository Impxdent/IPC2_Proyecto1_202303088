using IPC2_Proyecto1_202303088.Estructuras;
using IPC2_Proyecto1_202303088.XML;
using IPC2_Proyecto1_202303088.Logica;
using IPC2_Proyecto1_202303088.Modelos;
using IPC2_Proyecto1_202303088.Graphviz;

namespace IPC2_Proyecto1_202303088
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaPaciente listaPacientes = new ListaPaciente();
            LectorXML lector = new LectorXML();
            Simulador simulador = new Simulador();

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("     MENU PRINCIPAL");
                Console.WriteLine("=========================");
                Console.WriteLine("1. Cargar XML");
                Console.WriteLine("2. Analizar pacientes");
                Console.WriteLine("3. Buscar paciente");
                Console.WriteLine("4. Mostrar pacientes cargados");
                Console.WriteLine("5. Limpiar memoria");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese ruta del XML: ");
                        string ruta = Console.ReadLine();
                        try
                        {
                            listaPacientes = lector.CargarPacientes(ruta);
                            Console.WriteLine("Los pacientes se cargaron exitosamente");
                            Console.WriteLine("Total de pacientes: " + listaPacientes.ContarPacientes());
                        }
                        catch
                        {
                            Console.WriteLine("Error al cargar el archivo");
                        }
                        
                        break;

                    case "2":
                        AnalizarPacientes(listaPacientes, simulador);
                        break;
                    case "3":
                        AnalizarPacientePorNombre(listaPacientes, simulador);
                        break;
                    case "4":
                        listaPacientes.MostrarPacientes();
                        break;
                    case "5":
                        listaPacientes.Limpiar();
                        Console.WriteLine("La memoria se limpio");
                        break;
                    case "6":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Error, ingrese una opcion valida");
                        break;
                }
            }
        }

        static void AnalizarPacientes(ListaPaciente lista, Simulador simulador)
        {
            NodoPaciente actual = lista.ObtenerCabeza();

            if (actual == null)
            {
                Console.WriteLine("Error, no hay pacientes cargados");
                return;
            }

            Console.WriteLine("Analisis de pacientes:");

            while (actual != null)
            {
                Paciente paciente = actual.Dato;

                Console.WriteLine("Paciente: " + paciente.Nombre);
                Console.WriteLine("Edad: " + paciente.Edad);
                Console.WriteLine("Tamaño de rejilla: " + paciente.M + " x " + paciente.M);
                Console.WriteLine("Periodos maximos: " + paciente.PeriodosMaximos);

                Console.WriteLine("Estado inicial de la rejilla:");

                int contagiadas = paciente.RejillaInicial.ContarContagiadas();
                int sanas = paciente.RejillaInicial.ContarSanas();

                Console.WriteLine("Celulas contagiadas: " + contagiadas);
                Console.WriteLine("Celulas sanas: " + sanas);

                GeneradorDot generador = new GeneradorDot();
                generador.GenerarImagen(paciente.RejillaInicial, paciente.Nombre + "_inicial");

                Console.WriteLine("Ejecutando simulacion");

                simulador.AnalizarPaciente(paciente);

                Console.WriteLine("Resultado final: " + paciente.Resultado);

                if (paciente.Resultado != "leve")
                {
                    Console.WriteLine("N (periodo donde inicia el patron): " + paciente.N);
                    Console.WriteLine("N1 (longitud del ciclo): " + paciente.N1);
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void AnalizarPacientePorNombre(ListaPaciente lista, Simulador simulador)
        {
            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Paciente paciente = lista.BuscarPaciente(nombre);

            if (paciente == null)
            {
                Console.WriteLine("Error, el paciente no fue encontrado");
                return;
            }

            Console.WriteLine("Paciente encontrado:");
            Console.WriteLine("Nombre: " + paciente.Nombre);
            Console.WriteLine("Edad: " + paciente.Edad);

            simulador.AnalizarPaciente(paciente);

            Console.WriteLine("Resultado: " + paciente.Resultado);

            if (paciente.Resultado != "leve")
            {
                Console.WriteLine("N: " + paciente.N);
                Console.WriteLine("N1: " + paciente.N1);
            }
        }
    }
}