using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelWithUsService.Models
{
    public class ReservaPaquete
    {
        [Required]
        [Column("IdA")]
        public int AgenciaID { get; set; }

        [Required]
        [Column("IdT")]
        public int TuristaID { get; set; }

        [Required]
        [Column("CodigoP")]
        public int Codigo { get; set; }

        [Column("CompAereaRP")]
        [MaxLength(40)]
        public string Aerolinea { get; set; }

        [Column("FechaSalidaRP")]
        [Required]
        public DateTime Salida { get; set; }

        [Column("CantParticipantes")]
        public int Participantes { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required]
        public decimal Precio { get; set; }

        public virtual Turista Turista { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual Paquete Paquete { get; set; }

    }

    /*
    ReservaPaquete(IdA,IdT,CódigoP,CompAéreaRP,FechaSalidaRP, 
    CantParticipantes,PrecioRP) 

    */
}