using IPC2_Proyecto1_202303088.Modelos;

namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class ListaPaciente
    {
        private NodoPaciente cabeza;

        public void Agregar(Paciente paciente)
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

        public Paciente BuscarPaciente(string nombre)
        {
            NodoPaciente actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.Nombre.ToLower() == nombre.ToLower())
                {
                    return actual.Dato;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        public int ContarPacientes()
        {
            int contador = 0;
            NodoPaciente actual = cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }

            return contador;
        }

        public void MostrarPacientes()
        {
            NodoPaciente actual = cabeza;
            int contador = 1;

            if (actual == null)
            {
                Console.WriteLine("Error, no hay pacientes cargados");
                return;
            }

            Console.WriteLine("Pacientes cargados:");

            while (actual != null)
            {
                Console.WriteLine(contador + ". " + actual.Dato.Nombre);
                contador++;
                actual = actual.Siguiente;
            }
        }
    }
}