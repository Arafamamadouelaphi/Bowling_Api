﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    /// <summary>
    /// Classe de gestion des Joueurs
    /// </summary>
    public class JoueurDTO
    {
        #region Properties
        public long Id { get; set; }
        public string Pseudo { get; set; }
        public ICollection<PartieDTO> PartieDTO { get; set; } = new List<PartieDTO>();
        #endregion
    }
    
    
}