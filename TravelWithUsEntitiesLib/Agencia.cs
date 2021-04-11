using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithUs.Models
{
    [Table("Agencia")]
    public class Agencia
    {
        [Required]
        [Column("IdA")]
        [Key]
        public int AgenciaID { get; set; }

        [Column("NombreA")]
        [MaxLength(40)]
        [Required]
        public string Nombre { get; set; }

        [Column("DireccionA")]
        [MaxLength(120)]
        [Required]
        public string Direccion { get; set; }

        [Column("EmailA")]
        [MaxLength(120)]
        [RegularExpression(@"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+")]
        [Required]
        public string Email { get; set; }

        [Column("NumFaxA")]
        [MaxLength(20)]
        public string Fax { get; set; }

        public virtual ICollection<ReservaIndividual> ReservasIndividuales { get; set; }
        public virtual ICollection<ReservaPaquete> ReservasPaquetes { get; set; }
        public virtual ICollection<ReservaExcursion> ReservasExcursiones{ get; set; }

        public Agencia()
        {
            this.ReservasIndividuales = new HashSet<ReservaIndividual>();
            this.ReservasPaquetes = new HashSet<ReservaPaquete>();
            this.ReservasExcursiones = new HashSet<ReservaExcursion>();
        }


    }
}