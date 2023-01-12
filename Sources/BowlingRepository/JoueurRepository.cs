using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BowlingRepository;

public class JoueurRepository:IJoueurRepository
{
    private readonly BowlingContext _context;

    public JoueurRepository()
    {
        _context = new BowlingContext();
    }

    public async Task<bool> Add(JoueurEntity joueur)
    {
        _context.Joueurs.Add(joueur);
         return await _context.SaveChangesAsync()  > 0;
    }

    public async Task<bool> Delete(long id)
    {
        using (var context = new BowlingContext())
        {
            JoueurEntity entity = context.Joueurs.Find(id);
            context.Joueurs.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }

    public async Task<bool> Update(JoueurEntity joueur)
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<JoueurEntity> GetJoueur(long id)
    {
        return await _context.Joueurs.FindAsync(id);
    }

    public async Task<IEnumerable<JoueurEntity>> GetAllJoueur()
    {
        return await _context.Joueurs.ToListAsync();
    }

    public async Task<JoueurEntity> GetJoueurByNom(string nom)
    {
        return await _context.Joueurs.FirstOrDefaultAsync(n => n.Pseudo == nom);
    }
}