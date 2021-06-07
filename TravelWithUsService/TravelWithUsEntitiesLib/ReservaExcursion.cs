using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelWithUsService.Models
{
    public class ReservaExcursion
    {
        [Required]
        [Column("IdT")]
        public int TuristaID { get; set; }

        [Required]
        [Column("IdA")]
        public int AgenciaID { get; set; }

        [Required]
        [Column("IdE")]
        public int ExcursionID { get; set; }

        public virtual Turista Turista { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual Excursion Excursion { get; set; }
    }
    /*
    ReservaExcursión(IdT,IdA,IdE)
    */
}