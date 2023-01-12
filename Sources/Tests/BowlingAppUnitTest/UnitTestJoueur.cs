using System;
using System.Collections.Generic;
using System.Linq;
using BowlingLib.Model;
using BowlingStub;
using Xunit;

namespace Test.BowlingAppUnitTest
{
    public class UnitTestJoueur
    {
        Joueur j = new Joueur("Paul");
        [Fact]
        public void TestConstructeur()
        {
            Assert.NotNull(j);
            Assert.Equal("Paul", j.Pseudo);
            Assert.NotEqual("joel", j.Pseudo);
        }
        //si l text n est

        [Fact]
        public void TestInvalidJoueur()
        {
            Assert.Throws<ArgumentException>(() => new Joueur(null));
        }
        //
        [Theory]
        [InlineData(true, false, "Augustin", "Augustinn", false)]
        [InlineData(true, true, "Amir", "Amir", true)]
        [InlineData(false, false, "Amir", "", false)]
        [InlineData(false, false, "Amir", null, false)]
        [InlineData(false, false, null, null, true)]
        [InlineData(false, false, null, "", false)]
        [InlineData(false, false, "", null, false)]
        [InlineData(false, false, "", "", true)]
        [InlineData(false, false, "f2", "f2", true)]
        public void TestContructeur(bool isFormated, bool isValid, string expectedPseudo, String pseudo, bool isEqual)
        {// formated:
            if (!isValid && !isFormated)
            {
                Assert.Throws<ArgumentException>
                    (
                    () => new Joueur(pseudo)
                    );
                return;
            }

            Joueur j = new Joueur(pseudo);


            if (!isEqual)
            {
                Assert.NotEqual(expectedPseudo, j.Pseudo);

            }
            // else
            // {


            // if (!isEqual)
            // {
            //   Assert.NotEqual(expectedPseudo, j.Pseudo);

            //  }
            if (isEqual)
            {
                Assert.Equal(expectedPseudo, j.Pseudo);

            }


        }

        //Test joueur avec stub 
        [Fact]
        public void TestJoueurStub()
        {
            StubJoueur stub = new StubJoueur();
            Assert.Equal(10, stub.GetAllJoueur(10).Result.Count());
        }


        //tester la methode remove
        [Fact]
        public void TestRemove()
        {
            StubJoueur stub = new StubJoueur();
            stub.Add(j);
            stub.Delete(j);
            //Compter le nombre de joueur dans un objet IEnumerable
            Assert.Equal(0, stub.GetAll().Result.Count());
        }


        /*
         * TEST AVEC LE STUB
         */

        [Fact]
        public void TestUpdate()
        {
            StubJoueur stub = new StubJoueur();
            Joueur j = new Joueur("Paul");
            stub.Add(j);
            j.setNom("Augustin");
            stub.Update(j);
            Assert.Equal("Augustin", stub.GetAll().Result.First().Pseudo);
        }




    }
}

