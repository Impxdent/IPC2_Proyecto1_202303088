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
                sw.WriteLine("digraph G {");
                sw.WriteLine("node [shape=plaintext];");

                sw.WriteLine("tabla [label=<");
                sw.WriteLine("<table border='1' cellborder='1' cellspacing='0'>");

                for (int i = 0; i < rejilla.Tamaño; i++)
                {
                    sw.WriteLine("<tr>");

                    for (int j = 0; j < rejilla.Tamaño; j++)
                    {
                        int valor = rejilla.Matriz[i, j];

                        if (valor == 1)
                        {
                            sw.WriteLine("<td bgcolor='red'>1</td>");
                        }
                        else
                        {
                            sw.WriteLine("<td>0</td>");
                        }
                    }

                    sw.WriteLine("</tr>");
                }

                sw.WriteLine("</table>");
                sw.WriteLine(">];");

                sw.WriteLine("}");
            }

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "dot";
            start.Arguments = "-Tpng " + dot + " -o " + png;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;

            Process proceso = Process.Start(start);
            proceso.WaitForExit();

            System.Console.WriteLine("Imagen generada: " + png);
        }
    }
}