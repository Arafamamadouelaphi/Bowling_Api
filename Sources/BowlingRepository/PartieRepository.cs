using System;
using BowlingEF.Context;
using BowlingEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingRepository.Interface
{
    public class PartieRepository : IpartieRepository
    {
        private readonly BowlingContext _context;
        public PartieRepository()
        {
            _context = new BowlingContext();
        }

        public async Task<PartieEntity> Add(PartieEntity partie)
        {

            var result = await _context.Parties.AddAsync(partie);
            await _context.SaveChangesAsync();
            return result.Entity;

            //_context.Parties.Add( partie);
            //return await _context.SaveChangesAsync() > 0;


        }

        public async Task<bool> Delete(long id)
        {
            using (var context = new BowlingContext())
            {
                PartieEntity entity = context.Parties.Find(id);
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

        public async Task<PartieEntity> GetDataWithId(long id)
        {
            var data = await _context.Parties.FirstOrDefaultAsync(n => n.Id == id);
            return data;
        }


        public async Task<bool> Update(PartieEntity _partie)
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


