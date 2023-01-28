using System;
using BowlingEF.Entities;

namespace BowlingService.Interfaces
{
    public interface IpartieService
    {
        public Task<bool> Add(PartieDTO _partie);
        public Task<bool> Delete(PartieDTO _partie);
        public Task<bool> Update(PartieDTO _partie);
        public Task<IEnumerable<PartieDTO>> GetAll();
        public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date);
        public Task<PartieDTO> GetDataWithName(string nom);
    }
}

