using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Model
{
    /// <summary>
    /// Classe Model Partie
    /// </summary>
    public class Partie:IEquatable<Partie>
    {
        #region Propriétés
        public ReadOnlyCollection<Frame> Frames { get; }
        public Joueur Joueur { get; private set; }
        private readonly long id;
        private DateTime date;
        private int? score = 0;
        private readonly List<Frame> frames = new();
        #endregion

        #region Encapsulation
        public int? Score { 
            get 
            {
                return GetScore();
            }
            private set { score = value; }
        }
        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }
        public long Id => id;
        #endregion

        #region Constructeurs

        /// <summary>
        ///  Constructeur
        /// </summary>
        /// <param name="joueur"></param>
        public Partie(Joueur joueur)
        {
            this.Joueur = joueur;
            Date = DateTime.Now;
            Frames = new ReadOnlyCollection<Frame>(frames);
        }

        public Partie(long id, Joueur joueur, List<Frame> frames,DateTime date, int? score) : this(joueur)
        {
            this.id = id;
            this.frames = frames;
            this.date = date;
            this.Score = score;
        }
        #endregion


        #region Méthodes
        /// <summary>
        /// Ajoute un frame à la partie
        /// </summary>
        /// <param name="frame"></param>
        public void AddFrame(Frame frame)
        {
            if (Frames.Contains(frame))
                throw new ArgumentException("Le frame existe déjà");
            frames.Add(frame);
        }


        /// <summary>
        /// Calcule le score de la partie
        /// </summary>
        /// <returns>le Score d'une partie</returns>
        public int? GetScore()
        {
            score = 0;
            for (int i = 0; i < Frames.Count; i++)
            {
                score += Frames[i].QuillesTombees;
                if (Frames[i].IsStrike && i < Frames.Count - 1)
                {
                    score += Frames[i + 1].QuillesTombees;
                    if (Frames[i + 1].IsStrike && i < Frames.Count - 2)
                    {
                        score += Frames[i + 2].QuillesTombees;
                    }
                }
                else if (Frames[i].IsSpare && i < Frames.Count - 1)
                {
                    score += Frames[i + 1].Lancer1.QuillesTombees;
                }
            }
            return score;
        }

        public bool Equals(Partie other)
        {
            return Joueur.Equals(Joueur) && Date.Equals(other.Date);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Partie);
        }

        public override int GetHashCode()
        {
            return Joueur.GetHashCode();
        }
        #endregion
    }
}
