using IPC2_Proyecto1_202303088.Modelos;
using IPC2_Proyecto1_202303088.Estructuras;

namespace IPC2_Proyecto1_202303088.Logica
{
    public class Simulador
    {
        public void AnalizarPaciente(Paciente paciente)
        {
            ListaEstado estados = new ListaEstado();

            Rejilla actual = paciente.RejillaInicial;
            string patronInicial = actual.ObtenerPatron();

            estados.Agregar(patronInicial, 0);

            for (int periodo = 1; periodo <= paciente.PeriodosMaximos; periodo++)
            {
                actual = actual.GenerarSiguiente();
                string patronActual = actual.ObtenerPatron();

                NodoEstado repetido = estados.Buscar(patronActual);

                if (repetido != null)
                {
                    int N = repetido.Periodo;
                    int N1 = periodo - N;

                    paciente.N = N;
                    paciente.N1 = N1;

                    if (N1 == 1)
                        paciente.Resultado = "mortal";
                    else
                        paciente.Resultado = "grave";

                    return;
                }

                estados.Agregar(patronActual, periodo);
            }

            paciente.Resultado = "leve";
        }
    }
}