  using BowlingEF.Entities;

namespace BowlingRepository.Interface;

/// <summary>
/// Interface de gestion des équipes
/// </summary>
public interface IEquipeRepository
{
    /// <summary>
    /// Méthode d'ajout d'une équipe
    /// </summary>
    /// <param name="equipe">l'équipe à ajouter</param>
    public void Add(EquipeEntity equipe);
    
    /// <summary>
    /// Méthode de mise à jour d'une équipe
    /// </summary>
    /// <param name="equipe">l'équipe à mettre à jour</param>
    public void Update(EquipeEntity equipe);
    
    /// <summary>
    /// Méthode de suppression d'une équipe
    /// </summary>
    /// <param name="equipe">l'équipe à supprimer</param>
    public void Delete(EquipeEntity equipe);
    
    /// <summary>
    /// Méthode de récupération d'une équipe
    /// </summary>
    /// <param name="id">l'id de l'équipe à récupérer</param>
    /// <returns>l'équipe</returns>
    public Task GetEquipe(int id);
    
    /// <summary>
    /// Méthode de récupération de toutes les équipes
    /// </summary>
    /// <returns>la liste des équipes</returns>
    public IEnumerable<EquipeEntity> GetAllEquipes();
}