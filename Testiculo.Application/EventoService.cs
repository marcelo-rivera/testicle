using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Testiculo.Application.Contratos;
using Testiculo.Application.Dtos;
using Testiculo.Domain;
using Testiculo.Persistence.Contratos;

namespace Testiculo.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;

        public EventoService(IGeralPersist geralPersist, 
                                IEventoPersist eventoPersist,
                                IMapper mapper)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralPersist.Add<Evento>(evento);
                
                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventosByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
 
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventosByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                  return null;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Delete - Evento não encontrado");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
                               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetallEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetallEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;

                //return eventos;
            }                                    
            catch (Exception ex)                                                                                                                        
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetallEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetallEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }                                    
            catch (Exception ex)                                                                                                                        
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventosByIdAsync(eventoId,includePalestrantes);
                if (evento == null) return null;

                var resultado = _mapper.Map<EventoDto>(evento);

                return resultado;
            }                                    
            catch (Exception ex)                                                                                                                        
            {
                throw new Exception(ex.Message);
            }
        }
    }

}