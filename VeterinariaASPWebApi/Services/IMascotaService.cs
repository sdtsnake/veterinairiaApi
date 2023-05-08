using VeterinariaASPWebApi.Dto;
using VeterinariaASPWebApi.Models;

namespace VeterinariaASPWebApi.Services
{
    public interface IMascotaService
    {
        Task delete(int id);
        IEnumerable<MascotaDto> findAll();
        Task<MascotaDto> findById(int id);
        Task<MascotaDto> save(MascotaPostDto mascotaPostDto);
        Task<MascotaDto> update(MascotaUpdateDto mascotaUpdateDto);
    }
}
