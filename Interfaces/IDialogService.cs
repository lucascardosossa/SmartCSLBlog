public interface IDialogService
{
    Task ShowErrorAsync(string title, string message, string button);
    Task ShowWarningAsync(string title, string message, string button);
}