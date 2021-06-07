namespace TravelWithUsService.DBContext.Repositories
{
    public class HotelEnPaquete
    {
        //hotelID	nombre	direccion	categoria
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public string Direccion { get; private set; }
        public int Categoria { get; private set; }
        public HotelEnPaquete(string nombre, string descripcion, string direccion, int categoria)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Direccion = direccion;
            this.Categoria = categoria;
        }
    }
}