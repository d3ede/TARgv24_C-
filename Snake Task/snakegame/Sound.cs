using NAudio.Wave;
using System;
using System.IO;

namespace SnakeGame
{
    public class Sound : IDisposable
    {
        private readonly string filename;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private bool isLooping;

        public Sound(string filename, bool loop = false)
        {
            this.filename = Path.Combine("Resources", filename);
            this.isLooping = loop;
        }

        public void Play()
        {
            try
            {
                Stop();

                audioFile = new AudioFileReader(filename);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();

                if (isLooping)
                {
                    outputDevice.PlaybackStopped += (s, a) =>
                    {
                        audioFile.Position = 0;
                        outputDevice.Play();
                    };
                }
                else
                {
                    outputDevice.PlaybackStopped += (s, a) =>
                    {
                        outputDevice.Dispose();
                        audioFile.Dispose();
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Sound Error]: {ex.Message}");
            }
        }

        public void Stop()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
            outputDevice = null;
            audioFile = null;
        }

        public void Dispose() => Stop();
    }
}
