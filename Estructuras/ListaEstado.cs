namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class ListaEstado
    {
        private NodoEstado cabeza;

        public void Agregar(string patron, int periodo)
        {
            NodoEstado nuevo = new NodoEstado(patron, periodo);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoEstado actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public NodoEstado Buscar(string patron)
        {
            NodoEstado actual = cabeza;

            while (actual != null)
            {
                if (actual.Patron == patron)
                    return actual;

                actual = actual.Siguiente;
            }

            return null;
        }
    }
}