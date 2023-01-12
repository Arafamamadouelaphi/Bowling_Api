using BowlingLib.Model;
using System;
using Business;

namespace BowlingStub
{
    public class StubEquipe : IDataManager<Equipe>
    {
        private List<Equipe> listEquipes = new List<Equipe>();
        public int nbrJ = 10,nbrE = 2;
        public StubEquipe()
        {
            
        }

        public async Task<bool> Add(Equipe data)
        {
            if (data != null)
            {
                listEquipes.Add(data);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Equipe data)
        {
            if (data != null)
            {
                listEquipes.Remove(data);
                return true;
            }
            return false;
        }

        public void Load()
        {
            for (int i = 0; i < nbrE; i++)
            {
                this.Add(new Equipe("Equipe " + i + 1));

                for (int k = 0; k < nbrJ; k++)
                {
                    listEquipes.ElementAt(i).AjouterJoueur(new Joueur("Joueur " + i + 1 + "-" + k + 1));

                }
            }
        }
        

        public async Task<IEnumerable<Equipe>>  GetAll()
        {
            Load();
            return listEquipes;
        }


        //mise à jour d'une équipe
        public async Task<bool> Update(Equipe data)
        {
            if (data != null)
            {
                int index = listEquipes.FindIndex(x => x.Id == data.Id);
                listEquipes[index] = data;
                return true;
            }
            return false;


        }
        

        public async Task<Equipe>  GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Equipe>> GetAllWithDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}