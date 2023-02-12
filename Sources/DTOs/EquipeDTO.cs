using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// Classe de gestion des equipes
    /// </summary>
    public class EquipeDTO
    {//les proprietés
        #region Propriétés
        public long Id { get; set; }
        public string Nom { get; set; }
        public ICollection<JoueurDTO> Joueurs { get; set; }
        #endregion
        #region Constructeurs
        //constructeur


        public EquipeDTO()
        {
            Joueurs = new List<JoueurDTO>();
        }
        #endregion
    }
}
