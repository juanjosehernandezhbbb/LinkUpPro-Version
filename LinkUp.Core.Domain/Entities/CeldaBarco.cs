namespace LinkUpPro.Domain.Entities;

public class CeldaBarco
{
    public int Id { get; set; }

    public int BarcoId { get; set; }
    public Barco Barco { get; set; }

    public int Fila { get; set; }
    public int Columna { get; set; }

    public bool Impactada { get; set; }
}
