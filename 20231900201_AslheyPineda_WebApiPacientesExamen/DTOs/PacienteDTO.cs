namespace _20231900201_AslheyPineda_WebApiPacientesExamen.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NumeroIdentidad { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }

    public class CrearPacienteDTO
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string NumeroIdentidad { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = string.Empty;
    }

    public class ActualizarPacienteDTO
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string NumeroIdentidad { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}