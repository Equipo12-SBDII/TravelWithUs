using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithUsService.Models
{
    [Table("Paquete")]
    public class Paquete
    {
        [Required]
        [Column("CodigoP")]
        [Key]
        public int Codigo { get; set; }

        [Column("DescripcionP")]
        [MaxLength(240)]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Precio { get; set; }

        [Column("DuracionP")]
        [Required]
        public TimeSpan Duracion { get; set; }


        public virtual ICollection<ReservaPaquete> ReservasPaquetes { get; set; }
        public virtual ICollection<Facilidad> Facilidades { get; set; }
        public int ExcursionID { get; set; }
        public virtual Excursion Excursion { get; set; }

        public Paquete()
        {
            this.ReservasPaquetes = new HashSet<ReservaPaquete>();
            this.Facilidades = new HashSet<Facilidad>();
        }
    }
    /*
    Paquete(CódigoP,DescripciónP,PrecioP,DuraciónP,IdE)
    */
}