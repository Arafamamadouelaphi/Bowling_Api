using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingEF.Entities
{
    /// <summary>
    /// Classe de gestion des parties
    /// </summary>
    public class PartieDTO
    {
        #region Properties
        
        public long Id { get; set; }

        public JoueurDTO Joueur { get; set; }
      
        public DateTime Date { get; set; }
        public ICollection<FrameDTO> FramesDTO { get; set; }
  
        public int? Score { get; set; }
        #endregion

        #region Constructors
        public PartieDTO()
        {
            FramesDTO = new List<FrameDTO>();
        }
        #endregion
    }
}
