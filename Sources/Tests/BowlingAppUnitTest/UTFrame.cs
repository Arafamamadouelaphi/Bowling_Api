using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingAppUnitTest
{
    public class UTFrame
    {
        [Fact]
        public void TestFrame()
        {
            Frame frame = new Frame(1);
            Assert.Equal(1, frame.Numero);
            Assert.Equal(10, frame.QuillesRestantes);
            Assert.Equal(0, frame.QuillesTombees);
            Assert.False(frame.IsStrike);
            Assert.False(frame.IsSpare);
        }

        [Fact]
        public void TestLancer()
        {
            Frame frame = new Frame(1);
            frame.Lancer(5);
            Assert.Equal(5, frame.QuillesTombees);
            Assert.Equal(5, frame.QuillesRestantes);
            Assert.False(frame.IsStrike);
            Assert.False(frame.IsSpare);
        }

        [Fact]
        public void TestLancer2()
        {
            Frame frame = new Frame(1);
            frame.Lancer(10);
            Assert.Equal(10, frame.QuillesTombees);
            Assert.Equal(0, frame.QuillesRestantes);
            Assert.True(frame.IsStrike);
            Assert.False(frame.IsSpare);
        }

        [Fact]
        public void TestLancer3()
        {
            Frame frame = new Frame(1);
            frame.Lancer(5);
            frame.Lancer(5);
            Assert.Equal(10, frame.QuillesTombees);
            Assert.Equal(0, frame.QuillesRestantes);
            Assert.False(frame.IsStrike);
            Assert.True(frame.IsSpare);
        }

        //test Avec un lancé négatif
        [Fact]
        public void TestLancer4()
        {
            Frame frame = new Frame(1);
            Assert.Throws<ArgumentException>(() => frame.Lancer(-5));
        }

        //test Avec un lancé supérieur à 10
        [Fact]
        public void TestLancer5()
        {
            Frame frame = new Frame(1);
            Assert.Throws<ArgumentException>(() => frame.Lancer(15));
        }

        //test avec le deuxième lancé du dernier frame est un strike
        [Fact]
        public void TestLancer6()
        {
            Frame frame = new Frame(10);
            frame.Lancer(0);
            frame.Lancer(10);
            Assert.False(frame.IsStrike);
        }

        //test avec le deuxième lancé du dernier frame est un spare
        [Fact]
        public void TestLancer7()
        {
            Frame frame = new Frame(10);
            frame.Lancer(5);
            frame.Lancer(5);
            Assert.True(frame.IsSpare);
        }

        //[Fact]
        //public void TestLancer8()
        //{
        //    Frame frame = new Frame(10);
        //    frame.Lancer(0);
        //    frame.Lancer(10);
        //    frame.Lancer(10);
        //    Assert.True(frame.IsStrike);
        //}
    }
}
