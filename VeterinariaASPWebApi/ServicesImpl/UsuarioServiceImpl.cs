using Microsoft.EntityFrameworkCore;
using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Models;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.ServicesImpl
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly VeterinariaContext _dbContext;

        public UsuarioServiceImpl(VeterinariaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task delete(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception($"El usuario con id {id} no existe.");
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<UsuaorioDto> findAll()
        {
            var usuarios = _dbContext.Usuarios.ToList();
            var usuarioDtos = usuarios.Select(usuario => new UsuaorioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,
                DocumentoIdentificacion = usuario.DocumentoIdentificacion,
                Estado = usuario.Estado,    
                Sexo = usuario.Sexo,
            });
            return usuarioDtos;
        }

        public async Task<UsuaorioDto> findById(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception($"El usuario con id {id} no existe.");
            }

            var usuarioDto = new UsuaorioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento= usuario.TipoDocumento,
                DocumentoIdentificacion = usuario.DocumentoIdentificacion,
                Estado= usuario.Estado,
                Sexo= usuario.Sexo, 
            };
            return usuarioDto;
        }

        public async Task<UsuaorioDto> save(UsuarioPostDto usuarioPostDto)
        {
            var usuarioExistente = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.DocumentoIdentificacion == usuarioPostDto.DocumentoIdentificacion);

            if (usuarioExistente != null)
            {
                throw new Exception("Ya existe un usuario con el mismo DocumentoIdentificacion.");
            }

            var usuario = new Usuario
            {
                Nombre = usuarioPostDto.Nombre,
                Apellido = usuarioPostDto.Apellido,
                TipoDocumento = usuarioPostDto.TipoDocumento,
                DocumentoIdentificacion = usuarioPostDto.DocumentoIdentificacion,
                Estado = usuarioPostDto.Estado,
                Sexo = usuarioPostDto.Sexo
            };

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            var usuarioDto = new UsuaorioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,  
                DocumentoIdentificacion = usuario.DocumentoIdentificacion,
                Estado = usuario.Estado,
                Sexo = usuario.Sexo,
            };
            return usuarioDto;
        }

        public async Task<UsuaorioDto> update(UsuaorioDto  usuaorioUpdateDto)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(usuaorioUpdateDto.Id);
            if (usuario == null)
            {
                throw new Exception($"El usuario con id {usuaorioUpdateDto.Id} no existe.");
            }

            // Verificar si ya existe otro usuario con el mismo DocumentoIdentificacion
            var otroUsuarioConMismoDocumento = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.DocumentoIdentificacion == usuaorioUpdateDto.DocumentoIdentificacion && u.UsuarioId != usuaorioUpdateDto.Id);

            if (otroUsuarioConMismoDocumento != null)
            {
                throw new Exception("Ya existe otro usuario con el mismo DocumentoIdentificacion.");
            }

            usuario.Nombre = usuaorioUpdateDto.Nombre;
            usuario.Apellido = usuaorioUpdateDto.Apellido;
            usuario.TipoDocumento = usuaorioUpdateDto.TipoDocumento;
            usuario.DocumentoIdentificacion = usuaorioUpdateDto.DocumentoIdentificacion;
            usuario.Estado = usuaorioUpdateDto.Estado;
            usuario.Sexo = usuaorioUpdateDto.Sexo;

            await _dbContext.SaveChangesAsync();

            var usuarioDto = new UsuaorioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                TipoDocumento = usuario.TipoDocumento,  
                DocumentoIdentificacion = usuario.DocumentoIdentificacion,
                Estado = usuario.Estado,
                Sexo = usuario.Sexo,    
            };
            return usuarioDto;
        }
    }


}

