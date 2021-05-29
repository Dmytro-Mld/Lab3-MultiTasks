using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTasking
{
    public class Player : IPlayer
    {
        private ManualResetEventSlim _manualResetEventSlim;
        private int _seconds;
        public Player()
        {
            _manualResetEventSlim = new ManualResetEventSlim();
            _manualResetEventSlim.Set();
            var thread = new Thread(PlayBack);
            thread.Start();
        }
        private void PlayBack()
        {
            while (true)
            {
                if (_manualResetEventSlim.IsSet)
                {
                    Thread.Sleep(1000);
                    _seconds++;
                }
                else
                {
                    _manualResetEventSlim.Wait();
                }
            }
        }
        public int GetSeconds()
        {
            return _seconds;
        }
        public void Pause()
        {
            _manualResetEventSlim.Reset();
        }

        public void Play()
        {
            _manualResetEventSlim.Set();
        }

        public bool IsPlaying()
        {
            return _manualResetEventSlim.IsSet;
        }
    }
}
