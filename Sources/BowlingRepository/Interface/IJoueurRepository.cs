using BowlingEF.Entities;

namespace BowlingRepository.Interface;

/// <summary>
/// Interface de gestion des joueurs
/// </summary>
public interface IJoueurRepository
{
    /// <summary>
    /// Méthode d'ajout d'un joueur
    /// </summary>
    /// <param name="joueur">le joueur à ajouter</param>
    /// <returns>le joueur ajouté</returns>
    public Task<JoueurEntity> Add(JoueurEntity joueur);
    
    /// <summary>
    /// Méthode de suppression d'un joueur
    /// </summary>
    /// <param name="id">l'id du joueur à supprimer</param>
    /// <returns>le joueur supprimé</returns>
    public Task<bool> Delete(long id);
    
    /// <summary>
    /// Méthode de mise à jour d'un joueur
    /// </summary>
    /// <param name="joueur">le joueur à mettre à jour</param>
    /// <returns>le joueur mis à jour</returns>
    public Task<bool> Update(JoueurEntity joueur);
    
    /// <summary>
    /// Méthode de récupération d'un joueur
    /// </summary>
    /// <param name="id">l'id du joueur à récupérer</param>
    /// <returns>le joueur</returns>
    public Task<JoueurEntity> GetJoueur(long id);
    
    /// <summary>
    /// Méthode de récupération de tous les joueurs
    /// </summary>
    /// <returns>la liste des joueurs</returns>
    public Task<IEnumerable<JoueurEntity>> GetAllJoueur();
    
    /// <summary>
    /// Méthode de récupération d'un joueur par son nom
    /// </summary>
    /// <param name="nom">le nom du joueur à récupérer</param>
    /// <returns>le joueur</returns>
    public Task<JoueurEntity> GetJoueurByNom(string nom);
}