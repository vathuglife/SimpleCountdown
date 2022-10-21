using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealSimpleCountdown.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*So, as far as I know, this class (MusicPageViewModel) is responsible for 
 connecting the C# class with the ListView in the XAML. In other words,
Any changes updated in the C# class (MusicPage.xaml.cs) will be updated on the
MusicPage.xaml file. (a.k.a the UI will be updated.)*/

/*Second Speculation: Why don't we just update the XAML within the MusicPage.xaml.cs file?
 I guess, that the MusicPage.xaml.cs itself is A PARTIAL CLASS (means that it will not function as normally 
as a proper class like this one. As a result, the ItemTemplate within the ListView in the MusicPage class 
won't be able to retrieve the data from that partial class. */

/*Third Note: CONTROLS MUST ALWAYS INTERACT DIRECTLY WITH THE VIEW MODEL! (calls the function within the VIEWMODEL, NOT ANYWHERE ELSE!!*/
namespace RealSimpleCountdown.ViewModels;

public partial class MusicPageViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<MusicDetails> songsList;    
    public MusicPageViewModel()
    {
        SongsList = new ObservableCollection<MusicDetails>();
    }

    [RelayCommand]
    async void AddSong()
    {
        string YouTubeURL = await App.Current.MainPage.DisplayPromptAsync("YouTube URL", "Enter a YouTube URL", "Okay", "Cancel");
        string DestFolder = @"E:\My Coding Shits\C# Shits\MAUI_Tests\RealSimpleCountdown\Resources\Songs";
        await YTAudioDownloader.GetSongInfo(YouTubeURL, DestFolder);
        await Task.Run(() => {
            if (!string.IsNullOrEmpty(YouTubeURL))
            {
                MusicDetails newSong = new MusicDetails()
                {
                    ImageDir = "music.png",
                    SongDetails = YTAudioDownloader.SongName
                };
                SongsList.Add(newSong);
            }
        });
        
    }

    /*[RelayCommand]
    void DeleteSong(string s)
    {
        if (SongsList.Contains(s))
        {
            SongsList.Remove(s);
        }
    }*/
}

