using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DTOs;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des frames
    /// </summary>
    public class FrameDTO
    {//proprieté
        #region Properties
        
        public long Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Lancer1 { get; set; }
        [Required]
        public int Lancer2 { get; set; }
        public int Lancer3 { get; set; }

        public PartieDTO Partie { get; set; }
        #endregion
    }
    
}