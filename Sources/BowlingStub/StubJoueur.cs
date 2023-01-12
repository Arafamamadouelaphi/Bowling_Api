using BowlingLib.Model;
using System;
using Business;

namespace BowlingStub
{
    public class StubJoueur : IDataManager<Joueur>

    {
        private List<Joueur> listJoueurs = new List<Joueur>();


        public async Task<bool> Add(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Add(data);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Remove(data);
                return  true;
            }
            return false;
        }

        public async Task<IEnumerable<Joueur>> GetAll()
        {
            return listJoueurs;
        }
        //n represente le nbr de joueurs a creer dans la liste
        public async Task<IEnumerable<Joueur> >GetAllJoueur(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                Add(new Joueur("Joueur " + i + 1));
            }
            return listJoueurs;
        }
        ///ged 
        public async Task<Joueur >GetDataWithId (int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Joueur> GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }//

        public async Task<bool> Update(Joueur data)
        {
            if (data != null)
            {

                int index = listJoueurs.FindIndex(x => x.Id == data.Id);
                listJoueurs[index] = data;
                return true;
            }
            return false;
        }

    }
}
