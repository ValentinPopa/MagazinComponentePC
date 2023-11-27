using MagazinComponentePC.Models.DBObjects;
using System.ComponentModel.DataAnnotations;

namespace MagazinComponentePC.Models
{
    public class DetaliiComandaModel
    {
        [Key]
        public Guid DetaliiId { get; set; }

        public Guid? ComandaId { get; set; }

        public Guid? ProdusId { get; set; }

        public int Cantitate { get; set; }

        public decimal PretProdus { get; set; }

        public virtual Comenzi? Comanda { get; set; }

        public virtual Produse? Produs { get; set; }
    }
}
