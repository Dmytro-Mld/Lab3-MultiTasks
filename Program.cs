using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTasking
{
    class Program
    {

        static void Main(string[] args)
        {
            var player = new Player();
            var playPauseThread = new Thread(HandlePlayPause);
            playPauseThread.Start(player);

            while (true)
            {
                Console.WriteLine(player.GetSeconds());
                Thread.Sleep(1000);
            }
        }

        private static void HandlePlayPause(Object p)
        {
            while (true)
            {
                var player = (Player) p;
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (player.IsPlaying())
                    {
                        player.Pause();
                    }
                    else
                    {
                        player.Play();
                    }
                }
            }
        }
    }
}