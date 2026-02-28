namespace IPC2_Proyecto1_202303088.Estructuras
{
    public class NodoEstado
    {
        public string Patron;
        public int Periodo;
        public NodoEstado Siguiente;

        public NodoEstado(string patron, int periodo)
        {
            Patron = patron;
            Periodo = periodo;
            Siguiente = null;
        }
    }
}