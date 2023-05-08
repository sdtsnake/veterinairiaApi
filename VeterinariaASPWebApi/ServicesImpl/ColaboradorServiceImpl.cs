using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Models;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.ServicesImpl
{
    public class ColaboradorServiceImpl : IColaboradorService
    {
        private readonly VeterinariaContext _dbContext;

        public ColaboradorServiceImpl(VeterinariaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task delete(int id)
        {
            var colaborador = await _dbContext.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                throw new Exception($"No se encontró ningún colaborador con el id {id}");
            }

            _dbContext.Colaboradores.Remove(colaborador);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ColaboradorDto> findAll()
        {
            var colaboradores = _dbContext.Colaboradores
                .Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Cargo = c.Cargo,
                    Especialidad = c.Especialidad,
                    DocumentoIdentificacion = c.DocumentoIdentificacion,
                    TipoDocumento = c.TipoDocumento
                })
                .ToList();

            return colaboradores;
        }

        public async Task<ColaboradorDto> findById(int id)
        {
            var colaborador = await _dbContext.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                throw new Exception($"No se encontró ningún colaborador con el id {id}");
            }

            return new ColaboradorDto
            {
                Id = colaborador.Id,
                Nombre = colaborador.Nombre,
                Apellido = colaborador.Apellido,
                Cargo = colaborador.Cargo,
                Especialidad = colaborador.Especialidad,
                DocumentoIdentificacion = colaborador.DocumentoIdentificacion,
                TipoDocumento = colaborador.TipoDocumento
            };
        }

        public async Task<ColaboradorDto> save(ColaboradorPostDto colaboradorPostDto)
        {
            var colaborador = new Colaborador
            {
                Nombre = colaboradorPostDto.Nombre,
                Apellido = colaboradorPostDto.Apellido,
                Cargo = colaboradorPostDto.Cargo,
                Especialidad = colaboradorPostDto.Especialidad,
                DocumentoIdentificacion = colaboradorPostDto.DocumentoIdentificacion.Value,
                TipoDocumento = colaboradorPostDto.TipoDocumento
            };

            await _dbContext.Colaboradores.AddAsync(colaborador);
            await _dbContext.SaveChangesAsync();

            return new ColaboradorDto
            {
                Id = colaborador.Id,
                Nombre = colaborador.Nombre,
                Apellido = colaborador.Apellido,
                Cargo = colaborador.Cargo,
                Especialidad = colaborador.Especialidad,
                DocumentoIdentificacion = colaborador.DocumentoIdentificacion,
                TipoDocumento = colaborador.TipoDocumento
            };
        }

        public async Task<ColaboradorDto> update(ColaboradorDto colaboradorDto)
        {

            // Buscar el colaborador por su ID
            var colaborador = await _dbContext.Colaboradores.FindAsync(colaboradorDto.Id);

            // Si no se encuentra el colaborador, lanzar excepción
            if (colaborador == null)
            {
                throw new ArgumentException($"No se encuentra el colaborador con ID {colaboradorDto.Id}");
            }

            // Actualizar los campos del colaborador con los valores del DTO
            colaborador.Nombre = colaboradorDto.Nombre;
            colaborador.Apellido = colaboradorDto.Apellido;
            colaborador.Cargo = colaboradorDto.Cargo;
            colaborador.Especialidad = colaboradorDto.Especialidad;
            colaborador.TipoDocumento = colaboradorDto.TipoDocumento;
            colaborador.DocumentoIdentificacion = colaboradorDto.DocumentoIdentificacion;

            try
            {
                // Guardar los cambios en la base de datos
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el colaborador en la base de datos", ex);
            }

            // Devolver el colaborador actualizado como DTO
            return new ColaboradorDto
            {
                Id = colaborador.Id,
                Nombre = colaborador.Nombre,
                Apellido = colaborador.Apellido,
                Cargo = colaborador.Cargo,
                Especialidad = colaborador.Especialidad,
                TipoDocumento = colaborador.TipoDocumento,
                DocumentoIdentificacion = colaborador.DocumentoIdentificacion
            };

        }
    }
}
