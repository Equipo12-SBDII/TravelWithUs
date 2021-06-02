using System.Collections.Generic;
using TravelWithUs.Models;
using System.Linq;

namespace TravelWithUs.DBContext.Repositories
{
    public class PaqueteSobreMedia
    {
        public int Codigo { get; private set; }
        public int Duracion { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }

        public PaqueteSobreMedia(int codigo, int duracion, string descripcion, decimal precio)
        {
            this.Codigo = codigo;
            this.Duracion = duracion;
            this.Descripcion = descripcion;
            this.Precio = precio;
        }

    }
}