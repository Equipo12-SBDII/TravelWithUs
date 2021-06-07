namespace TravelWithUsService.DBContext.Repositories
{
    public class TuristaIndividualRepitente
    {
        public string NombreTurista { get; private set; }
        public string EmailTurista { get; private set; }
        public int CantidadViajes { get; private set; }

        public TuristaIndividualRepitente(string nombre, string email, int viajes)
        {
            this.NombreTurista = nombre;
            this.EmailTurista = email;
            this.CantidadViajes = viajes;
        }
    }
}