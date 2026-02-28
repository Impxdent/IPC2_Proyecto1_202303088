namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class ListaPaciente
    {
        private NodoPaciente cabeza;

        public void Agregar(Modelos.Paciente paciente)
        {
            NodoPaciente nuevo = new NodoPaciente(paciente);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoPaciente actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public NodoPaciente ObtenerCabeza()
        {
            return cabeza;
        }

        public void Limpiar()
        {
            cabeza = null;
        }
    }
}