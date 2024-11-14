using Microsoft.AspNetCore.Mvc;
using Testiculo.Persistence;
using Testiculo.Domain;
using Testiculo.Persistence.Contexto;
using Testiculo.Application.Contratos;
using System.Diagnostics.Tracing;
using Testiculo.Application.Dtos;

namespace Testiculo.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoteController : ControllerBase
    {
        // public IEnumerable<Evento> _evento = new Lote[] {
        //         new Lote(){
        //             LoteId = 1,
        //             Tema = "Angula 11 e .NET 5",
        //             Local = "Belo Horizonte",
        //             Lote = "1º lote",
        //             QtdPessoas = 250,
        //             DataEvento = DateTime.Now.AddDays(2),
        //             ImagemURL = "foto.png"
        //         },
        //         new Lote(){
        //             LoteId = 2,
        //             Tema = "Angular 11 e suas novidades",
        //             Local = "São Paulo",
        //             Lote = "2º lote",
        //             QtdPessoas = 350,
        //             DataEvento = DateTime.Now.AddDays(5),
        //             ImagemURL = "foto2.png"
        //         }
        // };
        
        //private readonly TesticuloContext _context;
        private readonly ILoteService _loteService;
        

        //public LoteController(TesticuloContext context)
        public LoteController(ILoteService loteService)
        {
        //    _context = context;
            _loteService = loteService;

            
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            //return _evento; 
            //return _context.Eventos;
            try
            {
                var eventos = await _eventoService.GetEventosByIdAsync(true);
                if (eventos == null) NoContent();

                // var eventosRetorno = new List<EventoDto>();

                // foreach (var evento in eventos)
                // {
                //     eventosRetorno.Add(new EventoDto() {
                //         Id = evento.Id,
                //         Local = evento.Local,
                //         DataEvento = evento.DataEvento.ToString(),
                //         Tema = evento.Tema,
                //         QtdPessoas = evento.QtdPessoas,
                //         ImagemURL = evento.ImagemURL,
                //         Telefone = evento.Telefone,
                //         Email = evento.Email
                //     });
                // }

                // return Ok(eventosRetorno); // 
                return Ok(eventos);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }
        }
        

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, LoteDto models)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento( eventoId, models);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var evento = await _eventoService.GetEventosByIdAsync(eventoId,true);
                if (evento == null) NoContent();

                return await _eventoService.DeleteEvento(id) ?
                    Ok(new { message = "Excluído"}) :
                    throw new Exception("Ocorreu um problema não específico ao tentar excluir Evento.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}