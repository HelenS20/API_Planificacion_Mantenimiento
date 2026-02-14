namespace API_Planificación_Mantenimiento.Services
{
    public interface IMantenimientoService
    {
        List<int> CalcularMantenimientos(
            int inicio,
            int fin,
            string tipo,
            int cada
        );
    }

}
