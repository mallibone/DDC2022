using System.ComponentModel;
using System.Diagnostics;
using MauiOClock.ViewModels;

namespace MauiOClock.Pages;

public partial class AnalogClockPage
{
    private readonly ClockViewModel _viewModel;
    private double _progress;
    private readonly ProgressArc _progressArc;

    public AnalogClockPage()
	{
		InitializeComponent();
        _viewModel = (ClockViewModel)BindingContext;
        _progressArc = new ProgressArc();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.PropertyChanged += ViewModelPropertyChanged;
        ProgressView.Drawable = _progressArc;
    }

    private void ViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch(e.PropertyName)
        {
            case nameof(ClockViewModel.LastDateTime):
                // https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/main-thread?WT.mc_id=AZ-MVP-5003494
                MainThread.BeginInvokeOnMainThread(UpdateArc);
                break;
            case nameof(ClockViewModel.Time):
                break;
            default: 
                Debug.WriteLine($"Unhandled property change: {e.PropertyName}");
                break;
        }
    }

    private void UpdateArc()
    {
        const int duration = 60;
        var timestamp = DateTime.Now;
        TimeSpan elapsedTime = timestamp - timestamp.AddSeconds(-timestamp.Second);

        _progress = Math.Ceiling(elapsedTime.TotalSeconds);
        _progress %= duration;
        _progressArc.Progress = _progress / duration;
        ProgressView.Invalidate();
    }
}