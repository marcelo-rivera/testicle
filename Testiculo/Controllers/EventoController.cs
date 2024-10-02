using Microsoft.AspNetCore.Mvc;
using Testiculo.Persistence;
using Testiculo.Domain;
using Testiculo.Persistence.Contexto;
using Testiculo.Application.Contratos;
using System.Diagnostics.Tracing;

namespace Testiculo.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        // public IEnumerable<Evento> _evento = new Evento[] {
        //         new Evento(){
        //             EventoId = 1,
        //             Tema = "Angula 11 e .NET 5",
        //             Local = "Belo Horizonte",
        //             Lote = "1º lote",
        //             QtdPessoas = 250,
        //             DataEvento = DateTime.Now.AddDays(2),
        //             ImagemURL = "foto.png"
        //         },
        //         new Evento(){
        //             EventoId = 2,
        //             Tema = "Angular 11 e suas novidades",
        //             Local = "São Paulo",
        //             Lote = "2º lote",
        //             QtdPessoas = 350,
        //             DataEvento = DateTime.Now.AddDays(5),
        //             ImagemURL = "foto2.png"
        //         }
        // };
        
        //private readonly TesticuloContext _context;
        private readonly IEventoService _eventoService;
        //public EventoController(TesticuloContext context)
        public EventoController(IEventoService eventoService)
        {
        //    _context = context;
            _eventoService = eventoService;

            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return _evento; 
            //return _context.Eventos;
            try
            {
                var eventos = await _eventoService.GetallEventosAsync(true);
                if (eventos == null) NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }
        }
        
        [HttpGet("{id}")]

        //public async Evento GetById(int id)
        public async Task<IActionResult> GetById(int id)
        {
            //return _evento.Where(evento => evento.EventoId == id);
            //return _context.Eventos.Where(evento => evento.Id == id);
            //return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
            try
            {
                var evento = await _eventoService.GetEventosByIdAsync(id,true);
                if (evento == null) NotFound("Nenhum evento encontrado - Id");

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }            
        }
        [HttpGet("{tema}/tema")]

        //public async Evento GetByTema(int id)
        public async Task<IActionResult> GetByTema(string tema)
        {
            //return _evento.Where(evento => evento.EventoId == id);
            //return _context.Eventos.Where(evento => evento.Id == id);
            //return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
            try
            {
                var evento = await _eventoService.GetallEventosByTemaAsync(tema, true);
                if (evento == null) NotFound("Nenhum evento encontrado - Tema");

                return Ok(evento);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro {ex.Message}");

            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento( id, model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ?
                    Ok("Excluído") :
                    BadRequest("Evento não excluído");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}