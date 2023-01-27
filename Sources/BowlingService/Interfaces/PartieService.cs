using System;
using AutoMapper;
using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using BowlingRepository;
using BowlingRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BowlingService.Interfaces
{
	public class PartieService:IpartieService
	{
        private readonly IpartieRepository _IpartieRepository;

        public PartieService(IpartieRepository ipartieRepository, IMapper mapper)
        {
            _IpartieRepository = ipartieRepository;
            _mapper = mapper;
        }

        public PartieService()
		{

		}
        private readonly IMapper _mapper;

        public async Task<bool> Add(PartieDTO _partie)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                PartieEntity entity = _mapper.Map<PartieEntity>(_partie);
                context.Parties.Add(entity);
                try
                {
                    var data = await context.SaveChangesAsync();
                    result = data == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            return result;
        }


        public async Task<bool> Delete(PartieEntity _partie)
        {
            return await _IpartieRepository.Delete(_partie);
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

        public Task<PartieEntity> GetDataWithName(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PartieEntity _partie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(PartieEntity _partie)
        {
            throw new NotImplementedException();
        }
    }
}

