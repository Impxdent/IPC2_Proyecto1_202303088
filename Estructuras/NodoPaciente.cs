using IPC2_Proyecto1_202303088.Modelos;

namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class NodoPaciente
    {
        public Paciente Dato;
        public NodoPaciente Siguiente;

        public NodoPaciente(Paciente paciente)
        {
            Dato = paciente;
            Siguiente = null;
        }
    }
}