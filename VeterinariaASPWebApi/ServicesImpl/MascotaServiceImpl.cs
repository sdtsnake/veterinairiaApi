using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Models;
using VeterinariaASPWebApi.Services;

namespace VeterinariaASPWebApi.ServicesImpl
{
    public class MascotaServiceImpl : IMascotaService
    {
        private readonly VeterinariaContext _context;
        private readonly IMapper mapper;

        public MascotaServiceImpl(VeterinariaContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task delete(int id)
        {
            if (_context.Mascotas == null)
            {
                throw new Exception("El contexto de Mascotas es nulo");
            }

            var mascota = _context.Mascotas.Find(id);

            if (mascota == null)
            {
                throw new Exception($"La mascota con id {id} no existe.");                
            }

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
        }

        public async Task<MascotaDto> findById(int id)
        {
            if (_context.Mascotas == null)
            {
                throw new Exception("El contexto de Mascotas es nulo");
            }
           
            var mascota = _context.Mascotas.Include(m => m.Usuario).SingleOrDefault(m => m.Id == id);


            if (mascota == null)
            {
                throw new Exception($"No existe la mascota por el id {id}");
            }

            var mascotaDto = new MascotaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Raza = mascota.Raza,
                Sexo = mascota.Sexo,
                UsuarioMascotaDto = mascota.Usuario == null ? null : new UsuarioMascotaDto
                {                    
                    Id = (int)mascota.UsuarioId,
                    Nombre = mascota.Usuario.Nombre,
                    Apellido = mascota.Usuario.Apellido,
                    DocumentoIdentificacion = mascota.Usuario.DocumentoIdentificacion
                }
            };

            return mascotaDto;
        }

        public async Task<MascotaDto> save(MascotaPostDto mascotaPostDto)
        {
            var usuario = await _context.Usuarios.FindAsync(mascotaPostDto.UsuarioId);

            if (usuario == null)
            {
                throw new Exception("El usuario asociado a la mascota no existe en la base de datos.");
            }

            var existingUsuario = _context.Usuarios.Local.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

            if (existingUsuario != null)
            {
                usuario = existingUsuario;
            }

            var mascota = new Mascota
            {
                Nombre = mascotaPostDto.Nombre,
                Raza = mascotaPostDto.Raza,
                Sexo = mascotaPostDto.Sexo,
                Usuario = usuario
            };

            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();

            return new MascotaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Raza = mascota.Raza,
                Sexo = mascota.Sexo,
                UsuarioMascotaDto = new UsuarioMascotaDto
                {                   
                    Id = usuario.UsuarioId,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    DocumentoIdentificacion = usuario.DocumentoIdentificacion
                }
            };
            
        }

        public async Task<MascotaDto> update(MascotaUpdateDto  mascotaUpdateDto)
        {
            // Buscar la mascota en la base de datos
            var mascota = await _context.Mascotas.FindAsync(mascotaUpdateDto.Id);

            // Si la mascota no existe, retornar null
            if (mascota == null)
            {
                throw new Exception($"No existe la mascota {mascota.Nombre}.");
            }
            
            var usuario = await _context.Usuarios.FindAsync(mascotaUpdateDto.UsuarioId);
          
            // Si la usario no existe, retornar null
            if (usuario == null)
            {
                throw new Exception($"No existe el usuario id {mascotaUpdateDto.UsuarioId} realacionado en la mascota.");
            }

            // Actualizar los campos de la mascota con los valores del DTO
            mascota.Nombre = mascotaUpdateDto.Nombre;
            mascota.Raza = mascotaUpdateDto.Raza;
            mascota.Sexo = mascotaUpdateDto.Sexo;
            mascota.Usuario = usuario;

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Retornar el DTO de la mascota actualizada
            return new MascotaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Raza = mascota.Raza,
                Sexo = mascota.Sexo,
                UsuarioMascotaDto = new UsuarioMascotaDto
                {
                    Id = usuario.UsuarioId,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,                 
                    DocumentoIdentificacion = usuario.DocumentoIdentificacion,                    
                }
            };
        }

        IEnumerable<MascotaDto> IMascotaService.findAll()
        {
            var mascotasDto = _context.Mascotas.Select(mascota => new MascotaDto
            {
                Id = mascota.Id,
                Nombre = mascota.Nombre,
                Raza = mascota.Raza,    
                Sexo = mascota.Sexo,                
                UsuarioMascotaDto = new UsuarioMascotaDto
                {
                    Id = (int)mascota.UsuarioId,
                    Nombre = mascota.Usuario.Nombre,
                    Apellido = mascota.Usuario.Apellido,
                    DocumentoIdentificacion = mascota.Usuario.DocumentoIdentificacion                     
                }
            }).ToList();
            return mascotasDto;
        }

       
    }
}
