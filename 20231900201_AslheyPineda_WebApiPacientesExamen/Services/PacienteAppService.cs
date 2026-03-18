using _20231900201_AslheyPineda_WebApiPacientesExamen.DTOs;
using _20231900201_AslheyPineda_WebApiPacientesExamen.Models;
using _20231900201_AslheyPineda_WebApiPacientesExamen.Repositories;

namespace _20231900201_AslheyPineda_WebApiPacientesExamen.Services
{
    public class PacienteAppService
    {
        private readonly IPacienteRepository _repository;
        private readonly PacienteDomainService _domainService;

        public PacienteAppService(IPacienteRepository repository, PacienteDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            var pacientes = await _repository.GetAllAsync();
            return pacientes.Select(p => new PacienteDTO
            {
                Id = p.Id,
                NombreCompleto = p.NombreCompleto,
                NumeroIdentidad = p.NumeroIdentidad,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
                Activo = p.Activo
            });
        }

        public async Task<PacienteDTO?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;
            return new PacienteDTO
            {
                Id = p.Id,
                NombreCompleto = p.NombreCompleto,
                NumeroIdentidad = p.NumeroIdentidad,
                FechaNacimiento = p.FechaNacimiento,
                Telefono = p.Telefono,
                Activo = p.Activo
            };
        }

        public async Task<PacienteDTO> CreateAsync(CrearPacienteDTO dto)
        {
            _domainService.ValidarPaciente(dto.NombreCompleto, dto.NumeroIdentidad, dto.Telefono, dto.FechaNacimiento);

            var paciente = new Paciente
            {
                NombreCompleto = dto.NombreCompleto,
                NumeroIdentidad = dto.NumeroIdentidad,
                FechaNacimiento = dto.FechaNacimiento,
                Telefono = dto.Telefono,
                Activo = true
            };

            var creado = await _repository.CreateAsync(paciente);
            return new PacienteDTO
            {
                Id = creado.Id,
                NombreCompleto = creado.NombreCompleto,
                NumeroIdentidad = creado.NumeroIdentidad,
                FechaNacimiento = creado.FechaNacimiento,
                Telefono = creado.Telefono,
                Activo = creado.Activo
            };
        }

        public async Task<PacienteDTO?> UpdateAsync(int id, ActualizarPacienteDTO dto)
        {
            _domainService.ValidarPaciente(dto.NombreCompleto, dto.NumeroIdentidad, dto.Telefono, dto.FechaNacimiento);

            var paciente = await _repository.GetByIdAsync(id);
            if (paciente == null) return null;

            paciente.NombreCompleto = dto.NombreCompleto;
            paciente.NumeroIdentidad = dto.NumeroIdentidad;
            paciente.FechaNacimiento = dto.FechaNacimiento;
            paciente.Telefono = dto.Telefono;
            paciente.Activo = dto.Activo;

            var actualizado = await _repository.UpdateAsync(paciente);
            return new PacienteDTO
            {
                Id = actualizado.Id,
                NombreCompleto = actualizado.NombreCompleto,
                NumeroIdentidad = actualizado.NumeroIdentidad,
                FechaNacimiento = actualizado.FechaNacimiento,
                Telefono = actualizado.Telefono,
                Activo = actualizado.Activo
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
