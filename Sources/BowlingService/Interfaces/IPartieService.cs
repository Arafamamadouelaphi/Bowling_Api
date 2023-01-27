using System;
using BowlingEF.Entities;

namespace BowlingService.Interfaces
{
	public interface IpartieService
    {
        public Task<bool> Add(PartieEntity _partie);
        public Task<bool> Delete(PartieEntity _partie);
        public Task<bool> Update(PartieEntity _partie);
        public Task<IEnumerable<PartieDTO>> GetAll();
        public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date);
        public Task<PartieEntity> GetDataWithName(string nom);
    }
}

