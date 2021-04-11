using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithUs.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Required]
        [Column("IdH")]
        [Key]
        public int HotelID { get; set; }

        [Column("NombreH")]
        [Required]
        [MaxLength(40)]
        public string Nombre { get; set; }

        [Column("DireccionH")]
        [Required]
        [MaxLength(120)]
        public string Direccion { get; set; }

        [Column("CategoriaH")]
        [Required]
        public int Categoria { get; set; }

        public virtual ICollection<Oferta> Ofertas { get; set; }
        public virtual ICollection<Excursion> Excursiones { get; set; }

        public Hotel()
        {
            this.Ofertas = new HashSet<Oferta>();
            this.Excursiones = new HashSet<Excursion>();
        }
    }
    /*
    Hotel(IdH,NombreH,DirecciónH,CategoríaH)
    */
}