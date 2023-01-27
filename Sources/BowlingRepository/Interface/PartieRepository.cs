using System;
using BowlingEF.Context;
using BowlingEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingRepository.Interface
{
	public class PartieRepository:IpartieRepository
    {
        private readonly BowlingContext _context;
        public PartieRepository()
        {
            _context = new BowlingContext();
        }

        public async Task<bool> Add(PartieEntity partie)
        {
            _context.Parties.Add( partie);
            return await _context.SaveChangesAsync() > 0;


        }

        public async Task<bool> Delete(PartieEntity _partie)
        {
            using (var context = new BowlingContext())
            {
                PartieEntity entity = context.Parties.Find(_partie.Id);
                context.Parties.Remove(entity);
                return await context.SaveChangesAsync() > 0;
            }
        }

      

        public async Task<List<PartieEntity>> GetAll()
        {
            return await _context.Parties.ToListAsync();
        }

        public Task<IEnumerable<PartieEntity>> GetAllWithDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<PartieEntity> GetDataWithName(string nom)
        {
            //  return await _context.Parties.FirstOrDefaultAsync(n => n == nom);
            throw new NotImplementedException();
        }

        public async Task<bool> Update(PartieEntity _partie)
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

