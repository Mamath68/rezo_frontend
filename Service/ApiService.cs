using System.Net.Http.Json;
using RezoFrontend.Models;

namespace RezoFrontend.Service;

public class ApiService(HttpClient http)
{
    public async Task<List<Permanence>> GetPermanences()
    {
        return await http.GetFromJsonAsync<List<Permanence>>("permanences")
               ?? [];
    }
}
