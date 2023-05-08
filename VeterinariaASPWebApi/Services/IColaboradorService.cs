using VeterinariaASPWebApi.Dto;

namespace VeterinariaASPWebApi.Services
{
    public interface IColaboradorService
    {
        Task delete(int id);
        IEnumerable<ColaboradorDto> findAll();
        Task<ColaboradorDto> findById(int id);
        Task<ColaboradorDto> save(ColaboradorPostDto colaboradorPostDto);
        Task<ColaboradorDto> update(ColaboradorDto colaboradorDto);
    }
}
