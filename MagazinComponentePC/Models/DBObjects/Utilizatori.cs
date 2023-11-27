using System;
using System.Collections.Generic;

namespace MagazinComponentePC.Models.DBObjects;

public partial class Utilizatori
{
    public Guid UserId { get; set; }

    public string Nume { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public DateTime DataInregistrare { get; set; }

    public virtual ICollection<Comenzi> Comenzis { get; set; } = new List<Comenzi>();
}
