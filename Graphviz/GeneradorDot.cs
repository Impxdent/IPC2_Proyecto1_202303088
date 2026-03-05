using System.Diagnostics;
using System.IO;
using IPC2_Proyecto1_202303088.Modelos;

namespace IPC2_Proyecto1_202303088.Graphviz
{
    public class GeneradorDot
    {
        public void GenerarImagen(Rejilla rejilla, string nombreArchivo)
        {
            string dot = nombreArchivo + ".dot";
            string png = nombreArchivo + ".png";

            using (StreamWriter sw = new StreamWriter(dot))
            {
                sw.WriteLine("graph G {");
                sw.WriteLine("node [shape=box style=filled width=0.5 height=0.5];");

                for (int i = 0; i < rejilla.Tamaño; i++)
                {
                    for (int j = 0; j < rejilla.Tamaño; j++)
                    {
                        string color = rejilla.Matriz[i, j] == 1 ? "red" : "white";
                        sw.WriteLine($"\"{i}_{j}\" [fillcolor={color}];");
                    }
                }

                sw.WriteLine("}");
            }

            ProcessStartInfo start = new ProcessStartInfo("dot");
            start.Arguments = "-Tpng " + dot + " -o " + png;
            start.UseShellExecute = true;
            start.CreateNoWindow = true;

            Process.Start(start);
        }
    }
}