using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithUsService.Models
{
    [Table("Excursion")]
    public class Excursion
    {
        [Required]
        [Column("IdE")]
        [Key]
        public int ExcursionID { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required]
        public decimal Precio { get; set; }

        [Column("DescripcionE")]
        [MaxLength(1000)]
        public string Descripcion { get; set; }

        [Column("FechaSalidaE")]
        [Required]
        public DateTime FechaSalida { get; set; }

        [Column("FechaLlegadaE")]
        [Required]
        public DateTime FechaLlegada { get; set; }

        // [Column("HoraSalidaE")]
        // [Required]
        // public DateTime HoraSalida { get; set; }

        // [Column("HoraLlegadaE")]
        // [Required]
        // public DateTime HoraLlegada { get; set; }

        [Column("LugarSalidaE")]
        [Required]
        [MaxLength(120)]
        public string LugarSalida { get; set; }

        [Column("LugarLlegadaE")]
        [Required]
        [MaxLength(120)]
        public string LugarLlegada { get; set; }


        public virtual ICollection<Hotel> Hoteles { get; set; }
        public virtual ICollection<ReservaExcursion> ReservasExcursiones { get; set; }
        public virtual ICollection<Paquete> Paquetes { get; set; }

        public Excursion()
        {
            this.Hoteles = new HashSet<Hotel>();
            this.ReservasExcursiones = new HashSet<ReservaExcursion>();
            this.Paquetes = new HashSet<Paquete>();
        }
    }
}

/*
Excursión(IdE,PrecioE,DíaSalidaE,DíaLlegadaE,HoraSalidaE,HoraLlegadaE,
LugarLlegadaE,LugarSalidaE)
*/