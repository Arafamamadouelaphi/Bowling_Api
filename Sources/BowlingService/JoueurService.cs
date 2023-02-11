using BowlingEF.Context;
using BowlingEF.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using AutoMapper;
using BowlingRepository.Interface;
using BowlingService.Interfaces;
using DTOs;

namespace BowlingService
{
    /// <summary>
    /// Classe de gestion des données des joueurs
    /// </summary>
    public class JoueurService : IJoueurService
    {
        
        private readonly ILogger<JoueurService> _logger;
        private readonly IJoueurRepository _joueurRepository;
        private readonly IMapper _mapper;
        
        #region Méthodes

        public JoueurService(IJoueurRepository joueurRepository,IMapper mapper , ILogger<JoueurService> logger)
        {
            _joueurRepository = joueurRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public async Task<JoueurDTO> Add(JoueurDTO _joueur)
        {
            JoueurDTO result = null;
            try
            {
                //Mapping entre la classe joueur et la classe joueurEntity
                JoueurEntity entity = _mapper.Map<JoueurEntity>(_joueur);
                entity.PartieEntities=_joueur.PartieDTO.Select(p =>
                {
                    var partieEntity = _mapper.Map<PartieEntity>(p);
                    partieEntity.Frames=p.FramesDTO.Select(f => _mapper.Map<FrameEntity>(f)).ToList();
                    return partieEntity;
                }).ToList();
                    
                result = _mapper.Map<JoueurDTO>(await _joueurRepository.Add(entity));
                _logger.LogInformation("A new player was added : {player}", _joueur.Pseudo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding new player : {player}", _joueur.Pseudo);
                throw;
            }
            return result;
        }

        /// <summary>
        /// Supprime un joueur de la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public async Task<bool> Delete(long _joueurId)
        {
            var result = false;
            try
            {
                result = await _joueurRepository.Delete(_joueurId);
                
                if (result)
                    _logger.LogInformation("A player was deleted : {player}", _joueurId);
                else
                    _logger.LogWarning("A player not found : {player}", _joueurId);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting player : {player}", _joueurId);
                throw;
            }
            return result;
        }

        /// <summary>
        /// recupère tous les joueurs de la Base de données
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<JoueurDTO>> GetAll()
        {
            List<JoueurDTO> joueurs = new  List<JoueurDTO>();
            try
            {
                var joueursEntity = await _joueurRepository.GetAllJoueur();
                joueurs = joueursEntity.Select(j => _mapper.Map<JoueurDTO>(j)).ToList();
                _logger.LogInformation("All players were retrieved");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all players");
                throw;
            }
            return joueurs;
        }

        /// <summary>
        /// recupère un joueur de la Base de données par son pseudo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<JoueurDTO> GetDataWithName(string name)
        {
            JoueurDTO _joueur = null;
            
            try
            {
                var joueurEntity = await _joueurRepository.GetJoueurByNom(name);
                _joueur = _mapper.Map<JoueurDTO>(joueurEntity);
                _logger.LogInformation("Player was retrieved : {player}", name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving player : {player}", name);
                throw;
            }
            return _joueur;
        }

        public async Task<bool> Update(long id,JoueurDTO _joueur)
        {
            bool result = false;
            try
            {
                JoueurEntity entity = _joueurRepository.GetJoueur(id).Result;
                if (entity!= null)
                {
                    entity.Pseudo = _joueur.Pseudo;
                    entity.PartieEntities = _joueur.PartieDTO.Select(p =>
                    {
                        var partieEntity = _mapper.Map<PartieEntity>(p);
                        partieEntity.Frames = p.FramesDTO.Select(f => _mapper.Map<FrameEntity>(f)).ToList();
                        return partieEntity;
                    }).ToList();
                    result = await _joueurRepository.Update(entity);
                    _logger.LogInformation("Player was updated : {player}", _joueur.Pseudo);
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating player : {player}", _joueur.Pseudo);
                throw;
            }
        }
        #endregion

    }
}
