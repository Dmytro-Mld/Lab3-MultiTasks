using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTasking
{
    public interface IPlayer
    {
        void Play();               

        void Pause();

        bool IsPlaying();
    }
}
