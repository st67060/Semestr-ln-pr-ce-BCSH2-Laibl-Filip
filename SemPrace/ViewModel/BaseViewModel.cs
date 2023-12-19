using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<bool> RequestDialogResult;
    public event EventHandler RequestClose;
    public event EventHandler RequestMinimize;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Confirm()
    {
        RequestDialogResult?.Invoke(this, true);
        Close();
    }

    public void Cancel()
    {
        RequestDialogResult?.Invoke(this, false);
        Close();
    }

    public void Close()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
    public void Minimize()
    {
        RequestMinimize?.Invoke(this, EventArgs.Empty);
    }
}

