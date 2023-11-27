using MagazinComponentePC.Models.DBObjects;
using System.ComponentModel.DataAnnotations;

namespace MagazinComponentePC.Models
{
    public class UtilizatoriModel
    {
        public Guid UserId { get; set; }

        public string Nume { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Parola { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataInregistrare { get; set; }

        public virtual ICollection<Comenzi> Comenzis { get; set; } = new List<Comenzi>();
    }
}