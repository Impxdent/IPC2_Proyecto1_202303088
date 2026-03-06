using System.Xml;
using IPC2_Proyecto1_202303088.Modelos;

namespace IPC2_Proyecto1_202303088.XML
{
    public class GeneradorXML
    {
        public void GenerarPaciente(Paciente paciente)
        {
            string archivo = paciente.Nombre + "_resultado.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(archivo, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("pacientes");

                writer.WriteStartElement("paciente");

                writer.WriteStartElement("datospersonales");
                writer.WriteElementString("nombre", paciente.Nombre);
                writer.WriteElementString("edad", paciente.Edad.ToString());
                writer.WriteEndElement();

                writer.WriteElementString("periodos", paciente.PeriodosMaximos.ToString());
                writer.WriteElementString("m", paciente.M.ToString());
                writer.WriteElementString("resultado", paciente.Resultado.ToUpper());

                if (paciente.Resultado.ToLower() != "leve")
                {
                    writer.WriteElementString("n", paciente.N.ToString());
                    writer.WriteElementString("n1", paciente.N1.ToString());
                }

                writer.WriteEndElement(); // paciente
                writer.WriteEndElement(); // pacientes

                writer.WriteEndDocument();
            }

            System.Console.WriteLine("XML generado: " + archivo);
        }
    }
}