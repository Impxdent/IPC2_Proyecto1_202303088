namespace IPC2_Proyecto1_202303088.Modelos
{
    public class Rejilla
    {
        public int Tamaño;
        public int[,] Matriz;

        public Rejilla(int tamaño)
        {
            Tamaño = tamaño;
            Matriz = new int[tamaño, tamaño];
        }

        // Contar vecinos contagiados
        public int ContarVecinos(int fila, int col)
        {
            int vecinos = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int nuevaFila = fila + i;
                    int nuevaCol = col + j;

                    if (nuevaFila >= 0 && nuevaFila < Tamaño &&
                        nuevaCol >= 0 && nuevaCol < Tamaño)
                    {
                        if (Matriz[nuevaFila, nuevaCol] == 1)
                            vecinos++;
                    }
                }
            }

            return vecinos;
        }

        // Generar siguiente período
        public Rejilla GenerarSiguiente()
        {
            Rejilla nueva = new Rejilla(Tamaño);

            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    int vecinos = ContarVecinos(i, j);

                    if (Matriz[i, j] == 1)
                    {
                        if (vecinos == 2 || vecinos == 3)
                            nueva.Matriz[i, j] = 1;
                        else
                            nueva.Matriz[i, j] = 0;
                    }
                    else
                    {
                        if (vecinos == 3)
                            nueva.Matriz[i, j] = 1;
                        else
                            nueva.Matriz[i, j] = 0;
                    }
                }
            }

            return nueva;
        }

        // Convertir estado en string para detectar repetición
        public string ObtenerPatron()
        {
            string patron = "";

            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    patron += Matriz[i, j];
                }
            }

            return patron;
        }

        // Contar células contagiadas
        public int ContarContagiadas()
        {
            int total = 0;

            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    if (Matriz[i, j] == 1)
                        total++;
                }
            }

            return total;
        }

        // Contar células sanas
        public int ContarSanas()
        {
            return (Tamaño * Tamaño) - ContarContagiadas();
        }
    }
}