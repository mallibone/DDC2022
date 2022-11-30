using System.Diagnostics;

namespace MauiOClock.Pages;

public class ProgressArc : IDrawable
{
    public double Progress { get; set; } = 100;
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Angle of the arc in degrees
        var endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
        
        // todo: get color from ressource dictionary
        // var primaryColor = (Color) ((Application.Current?.Resources["Colors"]["Primary"] ?? Color.FromRgba("512BD4"));
        // canvas.StrokeColor = primaryColor;
        // draw the stroke
        canvas.StrokeColor = Color.FromRgba("512BD4");
        canvas.StrokeSize = 4;
        Debug.WriteLine($"The rect width is {dirtyRect.Width} and height is {dirtyRect.Height}");
        canvas.DrawArc(5, 5, (dirtyRect.Width - 10), (dirtyRect.Height - 10), 90, endAngle, false, false);
    }
}