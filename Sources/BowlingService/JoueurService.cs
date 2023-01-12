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
        public async Task<bool> Add(JoueurDTO _joueur)
        {
            bool result = false;
            try
                {
                    //Mapping entre la classe joueur et la classe joueurEntity
                    JoueurEntity entity = new JoueurEntity
                    {
                        Id = _joueur.Id,
                        Pseudo = _joueur.Pseudo,
                    };

                    //Parcourt de la liste des parties d'un joueur
                    for (int i = 0; i < _joueur.PartieDTO.Count; i++)
                    {
                        //Mapping entre les parties d'un joueur et les partieEntity d'une partieEntity
                        PartieEntity partieEntity = _mapper.Map<PartieEntity>(_joueur.PartieDTO.ElementAt(1));

                        //Parcourt de la liste des frames d'une partie
                        for (int j = 0; j < _joueur.PartieDTO.ElementAt(i).FramesDTO.Count; j++)
                        {
                            //Mapping entre les frames d'une partie et les frameEntity d'une partieEntity
                            FrameEntity frameEntity = _mapper.Map<FrameEntity>(_joueur.PartieDTO.ElementAt(i).FramesDTO.ElementAt(j));
                            partieEntity.Frames.Add(frameEntity);
                        }
                        entity.PartieEntities.Add(partieEntity);
                    }
                    result = await _joueurRepository.Add(entity);
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
                foreach (var item in data)
                    joueurs.Add(_mapper.Map<JoueurDTO>(item));
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
            using (var context = new BowlingContext())
            {
                JoueurDTO _joueur = null;

                var query = _joueurRepository.GetJoueurByNom(name);
                _joueur = _mapper.Map<JoueurDTO>(query.Result);
                return _joueur;
            }
        }

        public async Task<bool> Update(JoueurDTO _joueur)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                JoueurEntity entity = _joueurRepository.GetJoueur(_joueur.Id).Result;
                if (entity!=null)
                {
                    entity.Pseudo = _joueur.Pseudo;
                    result = _joueurRepository.Update(entity).Result;
                }
            }
            return result;
        }
        #endregion

    }
}
