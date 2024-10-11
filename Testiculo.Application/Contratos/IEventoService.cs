using Testiculo.Application.Dtos;

namespace Testiculo.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto model);    
        Task<EventoDto> UpdateEvento(int eventoId,EventoDto model);    
        Task<bool> DeleteEvento(int eventoId);   

        Task<EventoDto[]> GetallEventosAsync(bool includePalestrantes = false);
        Task<EventoDto[]> GetallEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);         
    }
}