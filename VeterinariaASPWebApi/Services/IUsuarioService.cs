using VeterinariaASPWebApi.Dto;

namespace VeterinariaASPWebApi.Services
{
    public interface IUsuarioService
    {    
        Task delete(int id);
        IEnumerable<UsuaorioDto> findAll();
        Task<UsuaorioDto> findById(int id);
        Task<UsuaorioDto> save(UsuarioPostDto usuarioPostDto);
        Task<UsuaorioDto> update(UsuaorioDto  usuaorioDto);
    }
}
