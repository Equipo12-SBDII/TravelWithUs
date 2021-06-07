using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithUsService.Models
{
    public class Oferta
    {
        [Required]
        [Column("IdH")]
        public int HotelID { get; set; }

        [Required]
        [Column("IdO")]
        public int OfertaID { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required]
        public decimal Precio { get; set; }

        [Column("DescripcionO")]
        [MaxLength(240)]
        public string Descripcion { get; set; }

        public virtual Hotel Hotel { get; set; }

        public ICollection<ReservaIndividual> ReservasIndividuales { get; set; }

        public Oferta()
        {
            this.ReservasIndividuales = new HashSet<ReservaIndividual>();
        }
    }
    /*
    Oferta(IdH,IdO,PrecioO,DescripciónO)
    */
}