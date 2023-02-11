using System;
using System.Xml.Linq;
using AutoMapper;
using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using BowlingRepository;
using BowlingRepository.Interface;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BowlingService.Interfaces
{
    public class PartieService : IpartieService
    {
        private readonly IpartieRepository _IpartieRepository;
        private readonly ILogger<JoueurService> _logger;
        private readonly IMapper _mapper;

        public PartieService(IpartieRepository ipartieRepository, IMapper mapper, ILogger<JoueurService> logger)
        {
            _IpartieRepository = ipartieRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public PartieService()
        {

        }

        //Add


public async Task<PartieDTO> Add(PartieDTO _partie)
        {

            PartieDTO result = null;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = _mapper.Map<PartieEntity>(_partie);
                //context.Parties.Add(entity);
                try
                {
                    //var data = await context.SaveChangesAsync();
                    result =_mapper.Map<PartieDTO>(await _IpartieRepository.Add(entity));
                    _logger.LogInformation("A new player was added : {player}", _partie.Id);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while adding new player : {player}", _partie.Id);
                    throw;
                }
            }

            return result;
        }
        //Delete

        public async Task<bool> Delete(PartieDTO _partie)
        {
            // return await _IpartieRepository.Delete(_partie.Id);

            var result = false;
            try
            {
                result = await _IpartieRepository.Delete(_partie.Id);
                _logger.LogInformation("la partie est supprimer", _partie.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting player : {player}", _partie.Id);
                throw;
            }
            return result;

        }

        public async Task<IEnumerable<PartieDTO>> GetAll()
        {
            List<PartieDTO> result = new List<PartieDTO>();
            using (var context = new BowlingContext())
            {
                foreach (PartieEntity entity in await _IpartieRepository.GetAll())
                {
                    JoueurDTO joueur = _mapper.Map<JoueurDTO>(entity.Joueur);
                    List<FrameDTO> frames = new List<FrameDTO>();
                    foreach (FrameEntity frameEntity in entity.Frames)
                    {
                        FrameDTO frame = _mapper.Map<FrameDTO>(frameEntity);
                        frames.Add(frame);
                    }
                    result.Add(_mapper.Map<PartieDTO>(entity));
                }
            }
            return result.OrderBy(item => item.Date).ToList<PartieDTO>();

        }

        public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<PartieDTO> GetDataWithId(long id)
        {
            PartieDTO _partie = null;

            try
            {
                var partientity = await _IpartieRepository.GetDataWithId(id);
                _partie = _mapper.Map<PartieDTO>(partientity);
                _logger.LogInformation("partie was retrieved : {partie}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving partie : {partie}", id);
                throw;
            }
            return _partie;
        }


        //Update

        public async Task<bool> Update(PartieDTO _partie)
        {

            bool result = false;
            try
            {
                PartieEntity entity=await _IpartieRepository.GetDataWithId(_partie.Id);
                entity.Date = _partie.Date;
                entity.Score = _partie.Score;
                result = await _IpartieRepository.Update(entity);
                if (result)
                {
                    _logger.LogInformation("partie was updated : {partie}", _partie.Id);
                }
                else
                {
                    _logger.LogInformation("partie was not updated : {partie}", _partie.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating player : {player}", _partie.Id);
                throw;
            }
            return result;

        }
    }
}


