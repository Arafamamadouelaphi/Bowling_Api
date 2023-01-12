
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    /// <summary>
    /// Classe Model Equipe
    /// </summary>
    public class Equipe:IEquatable<Equipe>
    {
        #region Propiéters
        public string Nom { get; private set; }
        public  long Id { get; private set; }

        public ReadOnlyCollection<Joueur> Joueurs { get; private set; }

        private readonly List<Joueur> joueurs = new List<Joueur>();
        #endregion

        #region Construteurs

        public Equipe(string nom)
        {
            Nom = nom;
            Joueurs = new ReadOnlyCollection<Joueur>(this.joueurs);
        }

        public Equipe(long id, string nom, params Joueur[] joueurs)
        {
            Id = id;
            Nom = nom;
            Joueurs = new ReadOnlyCollection<Joueur>(this.joueurs);
            AjouterJoueurs(joueurs);
        }

        public Equipe(string nom, params Joueur[] joueurs)
            : this(0, nom, joueurs) {}

        #endregion

        #region Méthodes

        /// <summary>
        /// Ajoute une liste de joueur à l'équipe
        /// </summary>
        /// <param name="joueurs"></param>
        /// <returns></returns>
        public IEnumerable<Joueur> AjouterJoueurs(params Joueur[] joueurs)
        {
            List<Joueur> result = new();
            result.AddRange(joueurs.Where(a => AjouterJoueur(a)));
            return result;


        }

        /// <summary>
        /// Ajouter un joueur s'il n'exciste pas dans la bd
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>

        public bool AjouterJoueur(Joueur joueur)
        {
            if (!IsExist(joueur))
            {
                joueurs.Add(joueur);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Supprimer un joueur
        /// </summary>
        /// <param name="joueur"></param>

        public void SupprimerJoueur(Joueur joueur)
        {
            joueurs.Remove(joueur);
        }
        

        /// <summary>
        /// Fonction permettant de vérifier si un joueur existe déjà dans la liste (l'équipe)
        /// </summary>
        /// <param name="nouvJoueur"></param>
        /// <returns></returns>
        public bool IsExist(Joueur nouvJoueur)
        {
            if (joueurs.Contains(nouvJoueur))
                return true;
            return false;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Equipe);
        }

        public override int GetHashCode()
        {
            return joueurs.GetHashCode();
        }

        public bool Equals(Equipe other)
        {
            return joueurs.Equals(other.joueurs);
        }
        #endregion

    }
}
