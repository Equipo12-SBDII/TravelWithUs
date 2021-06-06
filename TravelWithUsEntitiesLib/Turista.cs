using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelWithUs.Models
{
    public class Turista
    {
        [Required]
        [Column("IdT")]
        [Key]
        public int TuristaID { get; set; }

        [Column("NombreT")]
        [MaxLength(120)]
        [MinLength(7)]
        [Required]
        public string Nombre { get; set; }

        [Column("NacionalidadT")]
        [MaxLength(120)] 
        public string Nacionalidad { get; set; }

        [Column("EmailT")]
        [MaxLength(120)]
        [RegularExpression("@[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+")]
        [Required]
        public string Email{ get; set;}


         
        public virtual ICollection<ReservaIndividual> ReservasIndividuales { get; set; }
        public virtual ICollection<ReservaPaquete> ReservasPaquetes { get; set; }
        public virtual ICollection<ReservaExcursion> ReservasExcursiones { get; set; }

        public Turista()
        {
            this.ReservasIndividuales = new HashSet<ReservaIndividual>();
            this.ReservasPaquetes = new HashSet<ReservaPaquete>();
            this.ReservasExcursiones = new HashSet<ReservaExcursion>();
        }


    }
    /*
    Turista(IdT,NombreT,Nacionalidad)
    */
}