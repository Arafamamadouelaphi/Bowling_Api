using System;
using BowlingEF.Entities;

namespace BowlingRepository.Interface
{
	public interface IpartieRepository
    {
      public  Task<bool> Add(PartieEntity _partie);
      public  Task<bool> Delete(PartieEntity _partie);
      public Task<bool> Update(PartieEntity _partie);
      public Task<List<PartieEntity>> GetAll();
      public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date);
      public Task<PartieEntity> GetDataWithName(string nom);
        
    }
}

