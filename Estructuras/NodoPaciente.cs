namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class NodoPaciente
    {
        public Modelos.Paciente Dato;
        public NodoPaciente Siguiente;

        public NodoPaciente(Modelos.Paciente dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}