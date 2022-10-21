namespace RealSimpleCountdown.Pages.TimerPage;
using Syncfusion.Maui.Sliders;
using RealSimpleCountdown.Objects;
using System.Threading;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;

public partial class CountdownPage : ContentPage
{
    private String[] dummyTextList = { "Hello there", "How are you doing", "How's the weather today?","Are you alright there???? Click me for more details!" };
    private Random random = new Random();
    private ProgressArc arcProgress = new ProgressArc();
    //An object that cancels the timer (I guess?)
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private DateTime startTime = DateTime.Now;
    private int duration;

    public CountdownPage(int inputDuration)
    {        
        InitializeComponent();        
        duration = inputDuration * 60 * 1000;              
        ProgressView.Drawable = arcProgress;        
        UpdateTimerArc();                        
    }    
    private async void UpdateTimerArc()
    {        
        while (!cancellationTokenSource.IsCancellationRequested)
        {            
            //Retrieves the current remaining time
            var elapsedTime = (DateTime.Now - startTime);
            int secondsRemaining = (int)(duration - elapsedTime.TotalMilliseconds)/1000 ;            
            
            //Updates the timer arc
            var progress = elapsedTime.TotalMilliseconds;
            progress %= duration;            
            arcProgress.Progress = progress / (float)duration;
            

            //Updates the remaining time LABEL
            TimeSpan t = TimeSpan.FromSeconds(secondsRemaining);
            string currentTimeRemaining = string.Format("{0}:{1}", t.Minutes, t.Seconds);
            arcProgress.TimeRemaining = currentTimeRemaining;
            ProgressView.Invalidate();

            //Updates the now playing song (right now it's just a dummy text)
            int randomIndex = random.Next(0, dummyTextList.Length-1);
            NowPlayingSong.Text = dummyTextList[randomIndex];
            
            if (secondsRemaining == 0)
            {
                arcProgress.Progress = 0;
                ProgressView.Invalidate();
                break;
            }
            else await Task.Delay(500);
        }
        arcProgress.TimeRemaining = "";
        await Navigation.PopAsync(false);

    }
    

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            var leave = await DisplayAlert("Reset session", "Do you really want to reset this working session?", "Yes", "No");
            if (leave == true)
            {                
                await Navigation.PopAsync(false);
            }
        });
        return true;
    }

}
    