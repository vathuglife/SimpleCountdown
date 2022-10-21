using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoLibrary;
using System.Diagnostics;
namespace RealSimpleCountdown.Objects
{
    internal class YTAudioDownloader
    {
        public static string SongName { get; set; }
        private static string URL { get; set; }
        private static string destination { get; set; }
        public static async Task GetSongInfo(string URL, string destination)
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(URL))
                {
                    var youtube = YouTube.Default;
                    var vid = youtube.GetVideo(URL);
                    var dest = destination;

                    var vidName = "\\" + vid.FullName;
                    var audioName = vidName.Split('.')[0].Remove(0, 1);
                    SongName = audioName;
                    Debug.WriteLine("Current audio name: " + audioName);
                    var fullPath = dest + vidName;
                    Debug.WriteLine("Current full path: " + fullPath);
                }
            });
        }


        private static async Task DownloadAudio()
        {
            await Task.Run(() =>
            {
                var youtube = YouTube.Default;
                var vid = youtube.GetVideo(URL);
                var dest = destination;
                var vidName = "\\" + vid.FullName;
                var audioName = vidName.Split('.')[0];
                SongName = audioName;
                Debug.WriteLine("Current audio name: " + audioName);
                var fullPath = dest + vidName;
                Debug.WriteLine("Current full path: " + fullPath);
                File.WriteAllBytes(fullPath, vid.GetBytes());
                Debug.WriteLine("Completed downloading the video!");

                var inputFile = new MediaFile { Filename = fullPath };
                var outputFile = new MediaFile { Filename = dest + "\\" + "DummyMP3.mp3" };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    Debug.WriteLine("I am still running!");
                    engine.Convert(inputFile, outputFile);
                    Debug.WriteLine("I am done converting!");
                }
            });

        }  
    }
}
