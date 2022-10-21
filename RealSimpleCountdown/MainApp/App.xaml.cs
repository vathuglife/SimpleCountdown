namespace RealSimpleCountdown;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        //Sets the first page of the app as the FlyoutMenu.
        MainPage = new MainUI(); 
       
    }
}
