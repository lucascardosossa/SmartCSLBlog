public class DialogService : IDialogService
{
    public async Task ShowErrorAsync(string title, string message, string button)
        => await Shell.Current.DisplayAlert(title, message, button);

    public async Task ShowWarningAsync(string title, string message, string button)
        => await Shell.Current.DisplayAlert(title, message, button);
}