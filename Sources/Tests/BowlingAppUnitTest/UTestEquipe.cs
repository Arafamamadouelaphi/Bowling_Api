using System;
using System.Collections.Generic;
using System.Linq;
using BowlingLib.Model; 
using Xunit;

namespace Test.BowlingAppUnitTest
{
    public class UnitTestEquipe
    {

        public static IEnumerable<object[]>  Data_AddJoueurToEquipe()
        {
            yield return new object[]
            {
                true,
                new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania"),
                    new Joueur("Cornelle")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                    new Joueur("Cornelle")
            };

            yield return new object[]
            {
                false,
                 new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                    new Joueur("Mania")
            };
        }


        [Theory]
        [MemberData(nameof(Data_AddJoueurToEquipe))]
        public void Test_AddJoueurToEquipe(bool expectedResult,
                                          IEnumerable<Joueur> expectedJoueurs,
                                          Equipe equipe,
                                          Joueur joueur)
        {
             
            bool result = equipe.AjouterJoueur(joueur);
            Assert.Equal(expectedResult, result);
            
            Assert.Equal(expectedJoueurs.Count(), equipe.Joueurs.Count());
            Assert.All(expectedJoueurs, j => equipe.Joueurs.Contains(j));

           
        }


        [Theory]
        [MemberData(nameof(TestData.Data_AddJoueurToEquipe), MemberType=typeof(TestData))]
        public void Test_AddJoueursToEquipe(int expectedResult,
                                   IEnumerable<Joueur> expectedJoueurs,
                                   IEnumerable<Joueur> expectedAddedJoueurs,
                                   Equipe equipe,
                                   params Joueur[] joueursToAdd)
        {
            var addedJoueurs = equipe.AjouterJoueurs(joueursToAdd);
            Assert.Equal(expectedResult, addedJoueurs.Count());

            Assert.All(expectedAddedJoueurs, a => addedJoueurs.Contains(a));

            Assert.Equal(expectedJoueurs.Count(), equipe.Joueurs.Count());
            Assert.All(expectedJoueurs, a => equipe.Joueurs.Contains(a));
        }


    }
}
