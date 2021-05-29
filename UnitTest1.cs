using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MultiTasking;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTaskingTests
{
    [TestClass]
    public class PlayPauseTest
    {
        [TestMethod]
        public void TestForPause()
        {
            var player1 = new Player();
            var player2 = new Player();
            var actual = player1.GetSeconds();
            player1.Pause();
            player2.Pause();
            var expected = player2.GetSeconds();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForPlay()
        {
            var player1 = new Player();
            var actual = player1.GetSeconds();
            player1.Pause();
            player1.Play();
            Thread.Sleep(5000);
            var expected = player1.GetSeconds();
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestForSeconds1()
        {
            var player1 = new Player();
            var actual = player1.GetSeconds();
            Thread.Sleep(5000);
            var expected = player1.GetSeconds();
            Assert.AreNotEqual(expected, actual);
        }
    }
}
