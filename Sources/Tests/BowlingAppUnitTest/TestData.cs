using BowlingLib.Model;
using System;
using System.Collections.Generic;

namespace Test.BowlingAppUnitTest
{
    public static class TestData
    {
        public static IEnumerable<object[]> Data_AddJoueurToEquipe()
        {
            yield return new object[]
            {
                1,
                new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania"),
                    new Joueur("Augustin")
                },
                new Joueur[]
                {
                    new Joueur("Augustin")
                },
                 new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                    new Joueur("Augustin")
            };

            yield return new object[]
            {
                2,
                new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania"),
                    new Joueur("Augustin")
                },
                new Joueur[]
                {
                    new Joueur("Mania"),
                    new Joueur("Augustin")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis")),

                    
                    new Joueur("Mania"),
                    new Joueur("Alys"),
                    new Joueur("Augustin")
            };

            yield return new object[]
            {
                1,
                new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania"),
                    new Joueur("Augustin")
                },
                new Joueur[]
                {
                    new Joueur("Augustin")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                new Joueur("Augustin"),
                new Joueur("Augustin")
            };
        }
    }
}
