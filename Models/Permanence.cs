namespace RezoFrontend.Models;

public class Permanence
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan PermanenceDebut { get; set; }
    public TimeSpan PermanenceFin { get; set; }

    public string Address { get; set; } = "";
    public string NomLocal { get; set; } = "";
    public string ShortLocal { get; set; } = "";
    public string Contact { get; set; } = "";
    public string PhoneContact { get; set; } = "";

    public List<Savoir> Savoirs { get; set; } = new();

    // 🧠 Propriétés calculées (clé pour l’agenda)
    public DateTime Start => Date.Date + PermanenceDebut;
    public DateTime End => Date.Date + PermanenceFin;
}
