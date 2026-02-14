namespace API_Planificación_Mantenimiento.Services
{
    public class MantenimientoService : IMantenimientoService
    {
        public List<int> CalcularMantenimientos(int inicio, int fin, string tipo, int cada)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("El tipo de recurrencia es obligatorio");

            var resultado = new List<int>();

            if (tipo == "ciclos")
            {
                for (int i = inicio; i <= fin; i += cada)
                {
                    resultado.Add(i);
                }
            }
            else if (tipo == "mantenimiento")
            {
                int contadorUso = 0;

                for (int i = inicio; i <= fin; i++)
                {
                    if (i % 2 != 0) // ciclos impares
                    {
                        contadorUso++;

                        if (contadorUso == cada)
                        {
                            if (i + 1 <= fin)
                                resultado.Add(i + 1);

                            contadorUso = 0;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Tipo de recurrencia inválido");
            }

            return resultado;
        }
    }

}
