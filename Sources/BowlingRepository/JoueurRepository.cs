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

    public async Task<JoueurEntity> Add(JoueurEntity joueur)
    {
        var result = await _context.Joueurs.AddAsync(joueur);  
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(long id)
    {
        JoueurEntity entity = _context.Joueurs.Find(id);
        _context.Joueurs.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
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