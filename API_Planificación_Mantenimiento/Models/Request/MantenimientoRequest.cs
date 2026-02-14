namespace API_Planificación_Mantenimiento.Models.Request
{
    public class MantenimientoRequest
    {
        public int CicloInicio { get; set; }
        public int CicloFin { get; set; }
        public required string TipoRecurrencia { get; set; }
        public int Cada { get; set; }
    }
}

