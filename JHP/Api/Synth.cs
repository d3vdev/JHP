using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace JHP.Api
{
    public class Synth
    {
        private static readonly Lazy<Synth> instance = new Lazy<Synth>(() => new Synth());
        public static Synth Instance { get { return instance.Value; } }
        private WaveOutEvent outputDevice;
        private AudioFileReader? audioFile;
        SpeechSynthesizer speechSynthesizer;

        public Synth()
        {
            speechSynthesizer = new SpeechSynthesizer();
            outputDevice = new WaveOutEvent();
            speechSynthesizer.SetOutputToDefaultAudioDevice();
            speechSynthesizer.SelectVoice("Microsoft Heami Desktop"); 
        }

        public void SetVolume(int vol)
        {
            Config.Instance.volume = vol;
            outputDevice.Volume = vol / 100.0f;
        }

        public void SetRate(int rate)
        {
            Config.Instance.rate = rate;
            speechSynthesizer.Rate = rate;
        }

        public void TTS(string tts)
        {
            Task.Run(() =>
            {
                speechSynthesizer.Speak(tts);
            });            
        }

        public void Stop()
        {
            outputDevice.Stop();
        }
        public void ResetAudioFile()
        {
            audioFile = null;
        }

        public void Ring()
        {
            if (audioFile == null)
            {
                audioFile = audioFile = new AudioFileReader(Path.Combine("alarm", (string)Config.Instance.alarmName));
                outputDevice.Stop();
                outputDevice.Init(audioFile);
            }
            audioFile.Position = 0;
            outputDevice.Play();
        }
    }
}
