using System.Runtime.CompilerServices;
using RealSimpleCountdown.Objects;
using System.Diagnostics;


namespace RealSimpleCountdown.Pages.TimerPage;


public partial class FirstPage : ContentPage
{
    private DropdownTimer TimerChoice = new DropdownTimer();
    public FirstPage()
    {
        InitializeComponent();
    }
    private async void DummyDownloader(object sender, EventArgs e)
    {
        //await YTAudioDownloader.DownloadAudio();
        
    }

    private async void Clicked(object sender,EventArgs e)
    {                        
        string timeString = TimerChoice.returnSelectedTime();
        if (!string.IsNullOrEmpty(timeString))
        {
            int duration = Int32.Parse(timeString.Substring(0, 2));
            Debug.WriteLine("Current timeString: {0} and duration: {1}", timeString, duration);
            await Navigation.PushAsync(new CountdownPage(duration));
        }
        else  await DisplayAlert("Empty timer","Timer can't be empty!","Okay");                
    }
      
    //A ContentPage function that automatically runs when the app is shown
    //(page is initialized in the App Class (App.xaml)
    /*IMPORTANT NOTE:
    - To display a GRAPHICAL ITEM (e.g. Timer arc,...), USE GraphicsView.
    - To display a REUSABLE, CUSTOMIZABLE ITEM (e.g. Buttons, Pickers, TextBoxes...), USE ContentView.*/
    protected override void OnAppearing()
    {        
        TimerDropdown.Content = TimerChoice;
    }
}