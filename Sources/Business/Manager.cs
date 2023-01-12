using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Classe pour gerer le jeux
    /// </summary>
    public class Manager
    {
        #region propriétés
        public ReadOnlyCollection<Partie> Parties { get; private set; }
        private readonly List<Partie> parties = new();
        public ReadOnlyCollection<Equipe> Equipes { get; private set; }
        private readonly List<Equipe> equipes = new();
        public ReadOnlyCollection<Joueur> Joueurs { get; private set; }
        private readonly List<Joueur> joueurs = new();
        

        public IDataManager<Joueur> JoueurDataManager => joueurDataManager;
        private readonly IDataManager<Joueur> joueurDataManager;
        public IDataManager<Partie> PartieDataManager => partieDataManager;
        private readonly IDataManager<Partie> partieDataManager;
        public IDataManager<Equipe> EquipeDataManager => equipeDataManager;
        private readonly IDataManager<Equipe> equipeDataManager;
        #endregion

        #region Constructeurs

        public Manager(IDataManager<Joueur> joueurManager)
        {
            this.joueurDataManager = joueurManager;
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);

        }

        public Manager(IDataManager<Partie> partieDataManager)
        {
            this.partieDataManager = partieDataManager;
            Parties = new ReadOnlyCollection<Partie>(parties);
        }
        
        
        public Manager(IDataManager<Equipe> equipeDataManager)
        {
            this.equipeDataManager = equipeDataManager;
            Equipes = new ReadOnlyCollection<Equipe>(equipes);
        }

        public Manager(IDataManager<Equipe> equipeDataManager, IDataManager<Partie> partieDataManager, IDataManager<Joueur> joueurManager)
        {
            this.equipeDataManager = equipeDataManager;
            Equipes = new ReadOnlyCollection<Equipe>(equipes);
            this.partieDataManager = partieDataManager;
            Parties = new ReadOnlyCollection<Partie>(parties);
            this.joueurDataManager = joueurManager;
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
        }
        #endregion

        #region Methodes

        /// <summary>
        /// Ajoute un joueur à la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public Task<bool> AddJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return Task.FromResult(false);
            }
                return joueurDataManager.Add(joueur);
            

        }

        /// <summary>
        /// Ajoute une partie à la liste des parties
        /// </summary>
        /// <param name="partie"></param>
        /// <returns></returns>
        public Task<bool> AddPartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return Task.FromResult( false);
            }
            return partieDataManager.Add(partie);
        }

        /// <summary>
        /// Ajoute une équipe à la liste des équipes
        /// </summary>
        /// <param name="equipe"></param>
        /// <returns></returns>
        public async Task<bool> AddEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return await equipeDataManager.Add(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public async Task<bool> DeleteJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return false;
            }
            return await JoueurDataManager.Delete(joueur);
        }

        /// <summary>
        /// Supprime une partie
        /// </summary>
        /// <param name="partie"></param>
        public async Task<bool> DeletePartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return false;
            }
            return await partieDataManager.Delete(partie);
        }

        /// <summary>
        /// Supprime une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public async Task<bool> DeleteEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return await equipeDataManager.Delete(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <param name="joueur"></param>
        public async Task<bool> UpdateJoueur(Joueur joueur)
        {
            if (joueurDataManager == null)
            {
                return false;
            }
            return await  JoueurDataManager.Update(joueur);
        }

        /// <summary>
        /// Met à jour une partie
        /// </summary>
        /// <param name="partie"></param>
        public async Task<bool> UpdatePartie(Partie partie)
        {
            if (partieDataManager == null)
            {
                return false;
            }
            return await partieDataManager.Update(partie);
        }

        /// <summary>
        /// Met à jour une équipe
        /// </summary>
        /// <param name="equipe"></param>
        public async Task<bool> UpdateEquipe(Equipe equipe)
        {
            if (equipeDataManager == null)
            {
                return false;
            }
            return await equipeDataManager.Update(equipe);
        }

        /// <summary>
        /// Retourne la liste des joueurs
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Joueur>> GetAllJoueur()
        {
            return await JoueurDataManager.GetAll();
        }

        /// <summary>
        /// Retourne les dernières parties du joueur
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Partie>> GetAllPartie()
        {
            return await partieDataManager.GetAll();
        }

        /// <summary>
        /// Retourne les Equipe en fonction d'une partie
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Equipe>> GetAllEquipe()
        {
            return await equipeDataManager.GetAll();
        }
        #endregion

    }
}
