namespace _20231900201_AslheyPineda_WebApiPacientesExamen.Services
{
    public class PacienteDomainService
    {
        public void ValidarPaciente(string nombreCompleto, string numeroIdentidad, string telefono, DateTime fechaNacimiento)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto))
                throw new ArgumentException("El nombre completo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(numeroIdentidad))
                throw new ArgumentException("El número de identidad no puede estar vacío.");

            if (numeroIdentidad.Length != 13)
                throw new ArgumentException("El número de identidad debe tener exactamente 13 caracteres.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío.");

            if (telefono.Length < 8)
                throw new ArgumentException("El teléfono debe tener al menos 8 dígitos.");

            if (fechaNacimiento > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser mayor a la fecha actual.");
        }
    }
}