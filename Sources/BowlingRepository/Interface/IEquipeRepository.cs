using BowlingEF.Entities;

namespace BowlingRepository.Interface;

public interface IEquipeRepository
{
    public void Add(EquipeEntity equipe);
    public void Update(EquipeEntity equipe);
    public void Delete(EquipeEntity equipe);
    public Task GetEquipe(int id);
    public IEnumerable<EquipeEntity> GetAllEquipes();
}