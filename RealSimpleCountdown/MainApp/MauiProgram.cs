namespace RealSimpleCountdown.MainApp;
using RealSimpleCountdown.ViewModels;
using RealSimpleCountdown.Pages.MusicPage;
using Microsoft.Maui.LifecycleEvents;
using Syncfusion.Maui.Core.Hosting;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()            
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<MusicPage>();
        builder.Services.AddSingleton<MusicPageViewModel>();

        #if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        window.ExtendsContentIntoTitleBar = false; /*This is important to prevent your app content extends into the title bar area.*/
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                        if (winuiAppWindow.Presenter is OverlappedPresenter p)
                        {
                            p.IsResizable = false;
                            p.IsMaximizable = false;
                        }
                        const int width = 800;
                        const int height = 600;
                        /*I suggest you to use MoveAndResize instead of Resize because this way you make sure to center the window*/
                        winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                    });
                });
            });
        #endif
        return builder.Build();
    }
}
