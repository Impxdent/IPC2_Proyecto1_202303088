using IPC2_Proyecto1_202303088.Estructuras;
using IPC2_Proyecto1_202303088.Modelos;
using IPC2_Proyecto1_202303088.Logica;

namespace IPC2_Proyecto1_202303088
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBA SIMULADOR ===");

            Paciente p = new Paciente();
            p.Nombre = "Paciente Prueba";
            p.Edad = 30;
            p.PeriodosMaximos = 10;
            p.M = 3;

            Rejilla r = new Rejilla(3);

            // Bloque estable (caso mortal porque se repite en 1)
            r.Matriz[0, 0] = 1;
            r.Matriz[0, 1] = 1;
            r.Matriz[1, 0] = 1;
            r.Matriz[1, 1] = 1;

            p.RejillaInicial = r;

            Simulador sim = new Simulador();
            sim.AnalizarPaciente(p);

            Console.WriteLine("Resultado: " + p.Resultado);
            Console.WriteLine("N: " + p.N);
            Console.WriteLine("N1: " + p.N1);
        }
    }
}