using _20231900201_AslheyPineda_WebApiPacientesExamen.Models;

namespace _20231900201_AslheyPineda_WebApiPacientesExamen.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<Paciente> UpdateAsync(Paciente paciente);
        Task<bool> DeleteAsync(int id);
    }
}