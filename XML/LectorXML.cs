using System.Xml;
using IPC2_Proyecto1_202303088.Modelos;
using IPC2_Proyecto1_202303088.Estructuras;

namespace IPC2_Proyecto1_202303088.XML
{
    public class LectorXML
    {
        public ListaPaciente CargarPacientes(string ruta)
        {
            ListaPaciente lista = new ListaPaciente();

            XmlDocument doc = new XmlDocument();
            doc.Load(ruta);

            XmlNodeList pacientes = doc.SelectNodes("//paciente");

            foreach (XmlNode nodoPaciente in pacientes)
            {
                Paciente p = new Paciente();

                p.Nombre = nodoPaciente["datospersonales"]["nombre"].InnerText;
                p.Edad = int.Parse(nodoPaciente["datospersonales"]["edad"].InnerText);
                p.PeriodosMaximos = int.Parse(nodoPaciente["periodos"].InnerText);
                p.M = int.Parse(nodoPaciente["m"].InnerText);

                Rejilla r = new Rejilla(p.M);

                XmlNode rejillaNode = nodoPaciente.SelectSingleNode("rejilla");

                if (rejillaNode != null)
                {
                    foreach (XmlNode celda in rejillaNode.SelectNodes("celda"))
                    {
                        int fila = int.Parse(celda.Attributes["f"].Value);
                        int columna = int.Parse(celda.Attributes["c"].Value);

                        r.Matriz[fila - 1, columna - 1] = 1;
                    }
                }

                p.RejillaInicial = r;
                lista.Agregar(p);
            }

            return lista;
        }
    }
}