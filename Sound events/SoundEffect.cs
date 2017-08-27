using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.DirectSound;
using CSCore.SoundOut;
using CSCore.Codecs;
using CSCore.Streams;
using CSCore.DSP;
using CSCore.Streams.Effects;
using CSCore.Codecs.WAV;
using System.IO;

namespace Sound_events
{
    public class SoundEffect : IDisposable
    {
        //Declarations required for audio out and the MP3 stream
        DirectSoundOut soundOut1;
        DirectSoundOut soundOut2;
        public Form1 parent;

        Timer timer;
        bool done;

        public SoundEffect(string a_soundFile, float a_vol, Event ev)
        {
            IWaveSource input = CodecFactory.Instance.GetCodec(a_soundFile);
            IWaveSource final = input;

            if (ev.UseEcho)
            {
                DmoEchoEffect echo = new DmoEchoEffect(input);
                echo.LeftDelay = ev.EchoAmount;
                echo.RightDelay = ev.EchoAmount;
                echo.WetDryMix = 40;
                final = echo;
            }

            soundOut1 = new DirectSoundOut(100, System.Threading.ThreadPriority.AboveNormal);
            soundOut1.Device = Helper.Out;
            soundOut1.Initialize(final);
            soundOut1.Volume = a_vol;
            soundOut1.Play();

            if (Helper.Mic != Helper.Out)
            {
                IWaveSource waveSource2 = CodecFactory.Instance.GetCodec(a_soundFile);
                IWaveSource final2 = waveSource2;

                if (ev.UseEcho)
                {
                    DmoEchoEffect echo = new DmoEchoEffect(waveSource2);
                    echo.LeftDelay = ev.EchoAmount;
                    echo.RightDelay = ev.EchoAmount;
                    echo.WetDryMix = 40;
                    final2 = echo;
                }

                soundOut2 = new DirectSoundOut(100, System.Threading.ThreadPriority.AboveNormal);
                soundOut2.Device = Helper.Mic;
                soundOut2.Initialize(final2);
                soundOut2.Volume = a_vol;
                soundOut2.Play();
            }

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (soundOut1 == null || done)
                return;

            if (soundOut1.PlaybackState == PlaybackState.Stopped)
            {
                parent.RemoveSound(this);
            }
        }

        public void Dispose()
        {
            CloseWaveOut();
        }

        private void CloseWaveOut()
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
            done = true;

            soundOut1.Stop();
            soundOut1.Dispose();

            if (soundOut2 != null)
            {
                soundOut2.Stop();
                soundOut2.Dispose();
            }

            soundOut1 = null;
            soundOut2 = null;
        }
    }
}
