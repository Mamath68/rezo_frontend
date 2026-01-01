using RezoFrontend.Service;

namespace RezoFrontend.Models;

public class CalendarViewModel(ApiService api)
{
    public List<Permanence> Permanences { get; private set; } = [];

    public async Task LoadAsync()
    {
        Permanences = await api.GetPermanences();
    }
}
