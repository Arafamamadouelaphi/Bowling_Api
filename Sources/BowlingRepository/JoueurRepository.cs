using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BowlingRepository;

/// <summary>
/// Repository class to manage data of players
/// </summary>
public class JoueurRepository:IJoueurRepository
{
    private readonly BowlingContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    public JoueurRepository()
    {
        _context = new BowlingContext();
    }

    /// <summary>
    /// Methode pour ajouter un joueur dans la base de données
    /// </summary>
    /// <param name="joueur"></param>
    /// <returns></returns>
    public async Task<JoueurEntity> Add(JoueurEntity joueur)
    {
        var result = await _context.Joueurs.AddAsync(joueur);  
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Methode pour supprimer un joueur de la base de données
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> Delete(long id)
    {
        JoueurEntity entity = _context.Joueurs.Find(id);
        if (entity == null)
        {
            return false;
        }
        _context.Joueurs.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    
    /// <summary>
    /// Methode pour mettre à jour un joueur de la base de données
    /// </summary>
    /// <param name="joueur"></param>
    /// <returns></returns>
    public async Task<bool> Update(JoueurEntity joueur)
    {
        return await _context.SaveChangesAsync() > 0; 
    }

    /// <summary>
    /// Methode pour récupérer un joueur de la base de données par son id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<JoueurEntity> GetJoueur(long id)
    {
        var data= await _context.Joueurs.FindAsync(id);
        return data;
    }

    /// <summary>
    /// Methode pour récupérer tous les joueurs de la base de données
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<JoueurEntity>> GetAllJoueur()
    {
        return await _context.Joueurs.ToListAsync();
    }

    /// <summary>
    /// Methode pour récupérer un joueur de la base de données par son pseudo
    /// </summary>
    /// <param name="nom"></param>
    /// <returns></returns>
    public async Task<JoueurEntity> GetJoueurByNom(string nom)
    {
        return await _context.Joueurs.FirstOrDefaultAsync(n => n.Pseudo == nom);
    }
}