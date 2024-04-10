namespace Cwiczenia_4.Models;

public class Wizyta
{
    public int Id { get; set; }
    public int ZwierzeId { get; set; }
    public DateTime DataWizyty { get; set; }
    public string Opis { get; set; }
    public decimal Cena { get; set; }
}