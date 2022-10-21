using System.Reflection; 
using Font = Microsoft.Maui.Graphics.Font;
using System.Windows.Input;

namespace RealSimpleCountdown.Objects;

public class ProgressArc : IDrawable
{
    public double Progress { get; set; }
    public string TimeRemaining { get; set; }
    public ProgressArc()
    {
        Progress = 100;
    }
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {     
        
        var endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
        canvas.StrokeColor = Color.FromRgba("6599ff");
        canvas.StrokeSize = 10;
        canvas.DrawArc(5, 5, dirtyRect.Width - 10, dirtyRect.Height - 10, 90, endAngle, false, false);

        canvas.Font = new Font("Quicksand");
        canvas.FontColor = Colors.White;
        canvas.FontSize = 50;
        canvas.DrawString(TimeRemaining, 32, 58, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    }         

}