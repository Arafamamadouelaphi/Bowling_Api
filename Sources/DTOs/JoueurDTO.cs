﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des Joueurs
    /// </summary>
    public class JoueurDTO
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Pseudo { get; set; }
        public ICollection<PartieDTO> PartieDTO { get; set; } = new List<PartieDTO>();
        #endregion
    }
}