using System;
using BowlingEF.Entities;
using DTOs;

namespace BowlingService.Interfaces
{
    public interface IpartieService
    {
        public Task<PartieDTO> Add(PartieDTO _partie);
        public Task<bool> Delete(PartieDTO _partie);
        public Task<bool> Update(PartieDTO _partie);
        public Task<IEnumerable<PartieDTO>> GetAll();
        public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date);
        public Task<PartieDTO> GetDataWithId(long id);
    }
}

