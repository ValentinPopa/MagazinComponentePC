using MagazinComponentePC.Models.DBObjects;
using System.ComponentModel.DataAnnotations;

namespace MagazinComponentePC.Models
{
    public class ProduseModel
    {
        [Key]
        public Guid ProdusId { get; set; }

        public string NumeProdus { get; set; } = null!;

        public string? Descriere { get; set; }

        public decimal Pret { get; set; }

        public int Stoc { get; set; }

        public virtual ICollection<DetaliiComanda> DetaliiComanda { get; set; } = new List<DetaliiComanda>();
    }
}
