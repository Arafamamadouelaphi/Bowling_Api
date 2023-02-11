using System;
using BowlingEF.Entities;

namespace BowlingRepository.Interface
{
    /// <summary>
    /// Interface de gestion des parties
    /// </summary>
	public interface IpartieRepository
    {
        /// <summary>
        /// Méthode d'ajout d'une partie
        /// </summary>
        /// <param name="_partie">la partie à ajouter</param>
        /// <returns></returns>
      public  Task<PartieEntity> Add(PartieEntity _partie);
      public  Task<bool> Delete(long id);
      public Task<bool> Update(PartieEntity _partie);
      public Task<List<PartieEntity>> GetAll();
      public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date);
      public Task<PartieEntity> GetDataWithId(long id);
        
    }
}

