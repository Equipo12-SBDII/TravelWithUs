using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelWithUs.Models
{
    public class ReservaIndividual
    {
        [Required]
        [Column("IdA")]
        public int AgenciaID { get; set; }

        [Required]
        [Column("IdT")]
        public int TuristaID { get; set; }

        [Required]
        [Column("IdH")]
        public int HotelID { get; set; }

        [Required]
        [Column("IdO")]
        public int OfertaID { get; set; }

        [Column("NumAcompanantes")]
        public int Acompanantes { get; set; }

        [Column("CompAereaRI")]
        [MaxLength(40)]
        public string Aerolinea { get; set; }

        [Column("PrecioRI")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public decimal Precio { get; set; }

        [Column("FechaLlegadaH")]
        [Required]
        public DateTime Llegada { get; set; }

        [Column("FechaSalidaH")]
        [Required]
        public DateTime Salida { get; set; }

        public virtual Turista Turista { get; set; }
        public virtual Agencia Agencia { get; set; }
        //public virtual Hotel Hotel { get; set; }
        public virtual Oferta Oferta { get; set; }
    }
    /*
    ReservaIndividual(IdA,IdT,IdH,IdO,NumAcompañantes,CompAéreaRI,PrecioRI, 
    FechaLlegadaH,FechaSalidaH)
    */
}