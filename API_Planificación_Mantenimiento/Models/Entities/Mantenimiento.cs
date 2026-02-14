namespace API_Planificación_Mantenimiento.Models.Entities
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public int CicloInicio { get; set; }
        public int CicloFin { get; set; }
        public string TipoRecurrencia { get; set; } = string.Empty;
        public int Cada { get; set; }
        public string Resultado { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

}
