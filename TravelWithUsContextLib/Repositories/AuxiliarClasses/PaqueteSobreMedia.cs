using System.Collections.Generic;
using TravelWithUs.Models;
using System.Linq;

namespace TravelWithUs.DBContext.Repositories
{
    public class PaqueteSobreMedia
    {
        public IEnumerable<Paquete> PaquetesSobreMedia { get; private set; }
        public int Count { get; private set; }

        public PaqueteSobreMedia(IEnumerable<Paquete> paquetes)
        {
            this.PaquetesSobreMedia = paquetes;
            this.Count = paquetes.ToArray().Length;
        }

    }
}