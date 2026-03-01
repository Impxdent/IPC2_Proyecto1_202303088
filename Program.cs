using IPC2_Proyecto1_202303088.Estructuras;
using IPC2_Proyecto1_202303088.XML;
using IPC2_Proyecto1_202303088.Logica;

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
                Console.WriteLine("3. Limpiar memoria");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese ruta del XML: ");
                        string ruta = Console.ReadLine();
                        listaPacientes = lector.CargarPacientes(ruta);
                        Console.WriteLine("Los pacientes se cargaron exitosamente");
                        break;

                    case "2":
                        AnalizarPacientes(listaPacientes, simulador);
                        break;

                    case "3":
                        listaPacientes.Limpiar();
                        Console.WriteLine("La memoria se limpio");
                        break;

                    case "4":
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

            while (actual != null)
            {
                simulador.AnalizarPaciente(actual.Dato);

                Console.WriteLine("Paciente: " + actual.Dato.Nombre);
                Console.WriteLine("Edad: " + actual.Dato.Edad);
                Console.WriteLine("Resultado: " + actual.Dato.Resultado);

                if (actual.Dato.Resultado != "leve")
                {
                    Console.WriteLine("N: " + actual.Dato.N);
                    Console.WriteLine("N1: " + actual.Dato.N1);
                }

                actual = actual.Siguiente;
            }
        }
    }
}