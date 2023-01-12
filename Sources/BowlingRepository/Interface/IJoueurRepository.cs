using BowlingEF.Entities;

namespace BowlingRepository.Interface;

public interface IJoueurRepository
{
    public Task<bool> Add(JoueurEntity joueur);
    public Task<bool> Delete(long id);
    public Task<bool> Update(JoueurEntity joueur);
    public Task<JoueurEntity> GetJoueur(long id);
    public Task<IEnumerable<JoueurEntity>> GetAllJoueur();
    public Task<JoueurEntity> GetJoueurByNom(string nom);
}