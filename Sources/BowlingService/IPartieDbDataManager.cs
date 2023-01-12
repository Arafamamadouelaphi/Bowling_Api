using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Classe d'abstraction pour les données de la partie
    /// </summary>
    public interface IPartieDbDataManager : IDataManager<Partie>
    {
        Task<IEnumerable<Partie>> GetAllWithDate(DateTime date);
    }
}
