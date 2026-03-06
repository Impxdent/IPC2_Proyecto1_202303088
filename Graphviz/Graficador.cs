using System.Diagnostics;
using System.IO;
using IPC2_Proyecto1_202303088.Estructuras;

namespace IPC2_Proyecto1_202303088.Graphviz
{
    public class Graficador
    {
        public void GraficarListaPacientes(ListaPaciente lista)
        {
            NodoPaciente actual = lista.ObtenerCabeza();

            if (actual == null)
            {
                System.Console.WriteLine("No hay pacientes para graficar");
                return;
            }

            string dot = "lista_pacientes.dot";
            string png = "lista_pacientes.png";

            using (StreamWriter sw = new StreamWriter(dot))
            {
                sw.WriteLine("digraph G {");
                sw.WriteLine("rankdir=LR;");
                sw.WriteLine("node [shape=box];");

                int i = 0;

                while (actual != null)
                {
                    sw.WriteLine($"n{i} [label=\"{actual.Dato.Nombre}\\nEdad: {actual.Dato.Edad}\"];");

                    if (actual.Siguiente != null)
                    {
                        sw.WriteLine($"n{i} -> n{i + 1};");
                    }

                    actual = actual.Siguiente;
                    i++;
                }

                sw.WriteLine("}");
            }

            ProcessStartInfo start = new ProcessStartInfo("dot");
            start.Arguments = "-Tpng " + dot + " -o " + png;
            start.UseShellExecute = true;
            start.CreateNoWindow = true;

            Process.Start(start);

            System.Console.WriteLine("Grafica generada: " + png);
        }
    }
}