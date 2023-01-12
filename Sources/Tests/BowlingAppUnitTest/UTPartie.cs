using BowlingLib.Model;
using BowlingStub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingAppUnitTest
{
    public class UTPartie
    {
        //le cas ou le joueur ne fait que des strikes
        [Fact]
        public void TestGetScore()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                partie.Frames[i].Lancer(10);
                if (i==9)
                {
                    partie.Frames[i].Lancer(10);
                }
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(300, score);
        }

        //le cas ou le joueur fait que des spares

        [Fact]

        public void TestGetScore2()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10)); 

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                partie.Frames[i].Lancer(5);
                partie.Frames[i].Lancer(5);
                if (i == 9)
                {
                    partie.Frames[i].Lancer(5);
                }

            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(150, score);
        }

        //le cas ou le joueur fait que des spares et des strikes

        [Fact]

        public void TestGetScore3()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                if (i % 2 == 0)
                {
                    partie.Frames[i].Lancer(10);
                }
                else
                {
                    partie.Frames[i].Lancer(5);
                    partie.Frames[i].Lancer(5);
                    if (i==9)
                    {
                        partie.Frames[i].Lancer(5);
                    }
                }
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(200, score);
        }

        //le cas ou le joueur ne fait aucun strike ou spare

        [Fact]

        public void TestGetScore4()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                partie.Frames[i].Lancer(5);
                partie.Frames[i].Lancer(4);
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(90, score);
        }

        //le cas ou le joueur fait un strike au dernier lancer

        [Fact]

        public void TestGetScore5()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                if (i < 9)
                {
                    partie.Frames[i].Lancer(5);
                    partie.Frames[i].Lancer(4);
                    continue;
                }
                partie.Frames[i].Lancer(10);
                if (partie.Frames[i].IsStrike)
                {
                    partie.Frames[i].Lancer(5);
                    partie.Frames[i].Lancer(4);
                }
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(100, score);
        }

        //le cas ou le joueur fait un spare au deuxieme lancer du dernier frame

        [Fact]

        public void TestGetScore6()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                if (i < 9)
                {
                    partie.Frames[i].Lancer(5);
                    partie.Frames[i].Lancer(4);
                    continue;
                }
                partie.Frames[i].Lancer(5);
                partie.Frames[i].Lancer(5);
                if (partie.Frames[i].IsSpare)
                {
                    partie.Frames[i].Lancer(5);
                }
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(96, score);
        }

        //le cas ou le nombre de lancer est atteind 2 eme frames

        [Fact]

        public void TestGetScore7()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            
            partie.Frames[0].Lancer(5);
            partie.Frames[0].Lancer(5);
            Assert.Throws<ArgumentException>
                (() => partie.Frames[0].Lancer(5));
        }

        //le cas ou les lancer sont finis

        [Fact]

        public void TestGetScore8()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            IEnumerable<Partie> listParties = stubPartie.GetAllPartie(1);
            Partie partie = listParties.ElementAt(0);
            partie.AddFrame(new Frame(1));
            partie.Frames[0].Lancer(5);
            partie.Frames[0].Lancer(5);
            Assert.True(partie.Frames[0].IsFinished);
        }
    }
}