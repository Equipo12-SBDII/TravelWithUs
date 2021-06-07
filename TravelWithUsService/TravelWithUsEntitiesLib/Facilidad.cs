using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelWithUsService.Models
{
    public class Facilidad
    {
        [Required]
        [Column("IdF")]
        [Key]
        public int FacilidadID { get; set; }

        [Column("DescripcionF")]
        [Required]
        [MaxLength(240)]
        public string Descripcion { get; set; }

        public virtual ICollection<Paquete> Paquetes { get; set; }

        public Facilidad()
        {
            this.Paquetes = new HashSet<Paquete>();
        }
    }

    /*
    Facilidad(IdF,descripciónF)
    */
}