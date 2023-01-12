
using BowlingEF.Context;
using BowlingEF.Entities;
using BowlingLib.Model;
using Business;
using Microsoft.EntityFrameworkCore;

namespace BowlingService
{
    public class EquipeDbDataManager : IDataManager<Equipe>
    {
        #region Méthodes
        public async Task<bool> Add(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = new EquipeEntity
                {
                    Id = _equipe.Id,
                    Nom = _equipe.Nom,
                    
                };

                for (int i = 0; i < _equipe.Joueurs.Count; i++)
                {
                    //Mapping entre la classe joueur et la classe joueurEntity
                    JoueurEntity joueurEntity = new JoueurEntity
                    {
                        Id = _equipe.Joueurs[i].Id,
                        Pseudo = _equipe.Joueurs[i].Pseudo,
                    };

                    //Parcourt de la liste des parties d'un joueur
                    for (int j = 0; j < _equipe.Joueurs[i].Parties.Count; j++)
                    {
                        //Mapping entre les parties d'un joueur et les partieEntity d'une partieEntity
                        PartieEntity partieEntity = new PartieEntity
                        {
                            Joueur = joueurEntity,
                            Date = _equipe.Joueurs[i].Parties[j].Date,
                            Score = _equipe.Joueurs[i].Parties[j].Score

                        };

                        //Parcourt de la liste des frames d'une partie
                        for (int k = 0; k < _equipe.Joueurs[i].Parties[j].Frames.Count; k++)
                        {
                            //Mapping entre les frames d'une partie et les frameEntity d'une partieEntity
                            FrameEntity frameEntity = new FrameEntity
                            {
                                Id = _equipe.Joueurs[i].Parties[j].Frames[k].Id,
                                Lancer1 = _equipe.Joueurs[i].Parties[j].Frames[k].Lancer1.QuillesTombees,
                                Lancer2 = _equipe.Joueurs[i].Parties[j].Frames[k].Lancer2.QuillesTombees,
                                Lancer3 = _equipe.Joueurs[i].Parties[j].Frames[k].Lancer3.QuillesTombees,
                                Partie = partieEntity
                            };
                            partieEntity.Frames.Add(frameEntity);
                        }
                        joueurEntity.PartieEntities.Add(partieEntity);
                    }
                    entity.Joueurs.Add(joueurEntity);


                }
                context.Equipes.Add(entity);
                await context.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<bool> Delete(Equipe _equipe)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity = context.Equipes.Find(_equipe.Id);
                context.Equipes.Remove(entity);
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<IEnumerable<Equipe>> GetAll()
        {
            using (var context = new BowlingContext())
            {
                return await  context.Equipes.Select(e => new Equipe 
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).ToListAsync();
            }
        }

        public async Task<Equipe> GetDataWithName(string name)
        {
            using (var context = new BowlingContext())
            {
                return await context.Equipes.Where(e => e.Nom == name).Select(e => new Equipe
                (
                    e.Id,
                    e.Nom,
                    e.Joueurs.Select(j => new Joueur(j.Id, j.Pseudo)).ToArray()
                )).FirstOrDefaultAsync();
            }
        }

        public async Task< bool> Update(Equipe data)
        {
            bool result = false;
            using (var context = new BowlingContext())
            {
                EquipeEntity entity =  context.Equipes.Find(data.Id);
                entity.Nom = data.Nom;
                entity.Joueurs = data.Joueurs.Select(j => new JoueurEntity
                {
                    Id = j.Id,
                    Pseudo = j.Pseudo
                }).ToList();
                result = await context.SaveChangesAsync() > 0;
            }
            return result;
        }
        #endregion
    }
}
