using BowlingLib.Model;
using System;
using Business;

namespace BowlingStub
{
    public class StubJoueur : IDataManager<Joueur>

    {
        // Liste pour stocker les joueurs
        private List<Joueur> listJoueurs = new List<Joueur>();

        /// <summary>
        /// Ajouter un joueur à la liste
        /// </summary>
        /// <param name="data">Joueur à ajouter</param>
        /// <returns>Retourne `true` si le joueur a été ajouté avec succès, sinon `false`</returns>
        public async Task<bool> Add(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Add(data);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Supprimer un joueur de la liste
        /// </summary>
        /// <param name="data">Joueur à supprimer</param>
        /// <returns>Retourne `true` si le joueur a été supprimé avec succès, sinon `false`</returns>
        public async Task<bool> Delete(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Remove(data);
                return  true;
            }
            return false;
        }
        /// <summary>
        /// Créer une liste de joueurs
        /// </summary>
        /// <param name="n">Nombre de joueurs à créer</param>
        /// <returns>Liste de joueurs</returns>
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
        // <summary>
        /// Obtenir un joueur en fonction de son identifiant
        /// </summary>
        /// <param name="id">Identifiant du joueur</param>
        /// <returns>Joueur correspondant à l'identifiant</returns>
        public async Task<Joueur >GetDataWithId (int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Obtenir un joueur en fonction de son nom
        /// </summary>
        /// <param name="name">Nom du joueur</param>
        /// <returns>Joueur correspondant au nom</returns>
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
