using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des frames
    /// </summary>
    public class FrameDTO
    {
        #region Properties
        
        public long Id { get; set; }
        public int Numero { get; set; }
        public int Lancer1 { get; set; }
        public int Lancer2 { get; set; }
        public int Lancer3 { get; set; }
        public PartieDTO Partie { get; set; }
        #endregion
    }
}