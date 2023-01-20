using BowlingEF.Context;
using BowlingEF.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using AutoMapper;
using BowlingRepository.Interface;
using BowlingService.Interfaces;

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

        public JoueurService(IJoueurRepository joueurRepository,IMapper mapper)
        {
            _joueurRepository = joueurRepository;
            _mapper = mapper;
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return result;
        }

        /// <summary>
        /// Supprime un joueur de la liste des joueurs
        /// </summary>
        /// <param name="_joueur"></param>
        /// <returns></returns>
        public async Task<bool> Delete(JoueurDTO _joueur)
        {
            return await _joueurRepository.Delete(_joueur.Id);
        }

        /// <summary>
        /// recupère tous les joueurs de la Base de données
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<JoueurDTO>> GetAll()
        {
            using (var context = new BowlingContext())
            {
                List<JoueurDTO> joueurs = new  List<JoueurDTO>();
                var data= await _joueurRepository.GetAllJoueur();
                
                joueurs= data.Select(j => _mapper.Map<JoueurDTO>(j)).ToList();
               
                return joueurs;
            }
        }

        /// <summary>
        /// recupère un joueur de la Base de données par son pseudo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<JoueurDTO> GetDataWithName(string name)
        {
            JoueurDTO _joueur = null;

            var query = _joueurRepository.GetJoueurByNom(name);
            _joueur = _mapper.Map<JoueurDTO>(query.Result);
            return _joueur;
        }

        public async Task<bool> Update(JoueurDTO _joueur)
        {
            bool result = false;
            JoueurEntity entity = _joueurRepository.GetJoueur(_joueur.Id).Result;
            if (entity!=null)
            {
                entity.Pseudo = _joueur.Pseudo;
                result = _joueurRepository.Update(entity).Result;
            } 
            return result;
        }
        #endregion

    }
}
