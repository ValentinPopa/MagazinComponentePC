using MagazinComponentePC.Models.DBObjects;
using System.ComponentModel.DataAnnotations;

namespace MagazinComponentePC.Models
{
    public class ComenziModel
    {
        [Key]
        public Guid ComandaId { get; set; }

        public Guid? UserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataComanda { get; set; }

        public string Stare { get; set; } = null!;

        public virtual ICollection<DetaliiComanda> DetaliiComanda { get; set; } = new List<DetaliiComanda>();

        public virtual Utilizatori? User { get; set; }
    }
}
