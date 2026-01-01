namespace RezoFrontend.Service;

public class TitleService
{
    public event Action? OnChange;
    public string Title { get; private set; } = "";

    public void SetTitle(string title)
    {
        Title = title;
        OnChange?.Invoke();
    }
}