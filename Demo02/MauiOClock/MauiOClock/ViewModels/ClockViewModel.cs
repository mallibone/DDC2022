using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiOClock.ViewModels;

public class ClockViewModel : INotifyPropertyChanged, IDisposable
{
    private readonly Timer _timer;
    private string _time = string.Empty;
    private DateTime _lastDateTime;

    public ClockViewModel()
    {
        _timer = new Timer(UpdateTime, null, 0, 250);
    }

    public DateTime LastDateTime
    {
        get => _lastDateTime;
        set
        {
            if (value.Equals(_lastDateTime)) return;
            _lastDateTime = value;
            OnPropertyChanged();
        }
    }

    public string Time
    {
        get => _time;
        set
        {
            if (value == _time) return;
            _time = value;
            OnPropertyChanged();
        }
    }

    private void UpdateTime(object? state)
    {
        LastDateTime = DateTime.Now;
        Time = LastDateTime.ToString("HH:mm:ss");
    }

    // INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}